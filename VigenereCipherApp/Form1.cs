using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VigenereCipherApp
{
    public partial class Form1 : Form
    {
        private const string RuL = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private const string EnL = "abcdefghijklmnopqrstuvwxyz";

        private const string RuA = RuL + "0123456789";
        private const string EnA = EnL + "0123456789";

        public Form1()
        {
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtInput.ScrollBars = ScrollBars.Vertical;

            comboBox1.Items.AddRange(new[] { "Русский", "Английский" });
            comboBox1.SelectedIndex = 0;
        }

        private string VigProc(string txt, string key, bool enc)
        {
            if (string.IsNullOrEmpty(txt) || string.IsNullOrEmpty(key))
                throw new ArgumentException("Текст или ключ не могут быть пустыми!");

            string lang = comboBox1.SelectedItem.ToString();
            string alpha = lang == "Русский" ? RuA : EnA;

            CheckInput(txt, key, alpha, lang);

            key = key.Replace(" ", "").ToLower();
            var res = new StringBuilder();
            int kp = 0;

            foreach (char ch in txt.ToLower())
            {
                int si = alpha.IndexOf(ch);
                if (si == -1)
                    throw new ArgumentException("Недопустимый символ");

                int ks = alpha.IndexOf(key[kp % key.Length]);
                int sh = enc ? ks : -ks;

                int ni = (si + sh + alpha.Length) % alpha.Length;
                res.Append(alpha[ni]);
                kp++;
            }

            return res.ToString();
        }

        private void CheckInput(string txt, string key, string alpha, string lang)
        {
            foreach (char c in key)
            {
                if (!alpha.Contains(c))
                    throw new ArgumentException("Ключ содержит недопустимый символ");
            }

            bool hasRu = txt.Any(c => RuL.Contains(c));
            bool hasEn = txt.Any(c => EnL.Contains(c));

            if (hasRu && lang != "Русский")
                throw new ArgumentException("Текст содержит русские буквы, но выбран английский алфавит!");

            if (hasEn && lang != "Английский")
                throw new ArgumentException("Текст содержит английские буквы, но выбран русский алфавит!");

            foreach (char c in txt)
            {
                if (!alpha.Contains(c))
                    throw new ArgumentException("Текст содержит недопустимый символ");
            }
        }

        private void ProcBtn(bool enc)
        {
            try
            {
                string txt = txtInput.Text;
                string key = tKey.Text;

                if (string.IsNullOrWhiteSpace(key))
                    throw new ArgumentException("Введите ключ!");

                txtOutput.Text = VigProc(txt, key, enc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enc_Click(object sender, EventArgs e) => ProcBtn(true);
        private void dec_Click(object sender, EventArgs e) => ProcBtn(false);

        private double CalcIC(string txt, string alpha)
        {
            int[] freq = new int[alpha.Length];
            foreach (char c in txt)
            {
                int idx = alpha.IndexOf(c);
                if (idx >= 0)
                    freq[idx]++;
            }

            int n = txt.Length;
            if (n < 2) return 0;

            double ic = 0;
            for (int i = 0; i < freq.Length; i++)
            {
                ic += freq[i] * (freq[i] - 1);
            }
            return ic / (n * (n - 1));
        }

        private int FindKeyLen(string ct, string alpha)
        {
            const int minK = 1;
            const int maxK = 20;
            double[] avgIC = new double[maxK + 1];

            for (int kl = minK; kl <= maxK; kl++)
            {
                double sumIC = 0;
                for (int i = 0; i < kl; i++)
                {
                    var grp = new StringBuilder();
                    for (int j = i; j < ct.Length; j += kl)
                        grp.Append(ct[j]);
                    sumIC += CalcIC(grp.ToString(), alpha);
                }
                avgIC[kl] = sumIC / kl;
            }

            double normIC = alpha == RuA ? 0.0529 : 0.0667;

            int bestK = minK;
            double bestD = Math.Abs(avgIC[minK] - normIC);
            for (int k = minK + 1; k <= maxK; k++)
            {
                double d = Math.Abs(avgIC[k] - normIC);
                if (d < bestD)
                {
                    bestD = d;
                    bestK = k;
                }
            }
            for (int i = 1; i < bestK; i++)
            {
                if (bestK % i == 0)
                {
                    double smIC = avgIC[i];
                    double lgIC = avgIC[bestK];
                    if (Math.Abs(smIC - lgIC) < 0.01)
                        return i;
                }
            }
            return bestK;
        }

        private string GuessKey(string ct, int kl, string alpha, char[] popC)
        {
            var key = new StringBuilder();
            int aLen = alpha.Length;
            int lCnt = alpha == EnA ? 26 : 32;

            double[] expF = alpha == EnA
                ? new double[] { 8.2, 1.5, 2.8, 4.3, 13, 2.2, 2.0, 6.1, 7.0, 0.15, 0.77, 4.0, 2.4, 6.7, 7.5, 1.9, 0.095, 6.0, 6.3, 9.1, 2.8, 0.98, 2.4, 0.15, 2.0, 0.074, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
                : new double[] { 8.01, 1.59, 4.54, 1.70, 2.98, 8.45, 0.04, 0.94, 1.65, 7.36, 1.21, 3.49, 4.40, 3.21, 6.70,
                                     10.97, 2.81, 4.73, 5.47, 6.26, 2.62, 0.26, 0.97, 0.48, 1.44, 0.73, 0.36, 0.04, 1.90, 1.74,
                                     0.32, 0.32, 0.64 };

            for (int i = 0; i < kl; i++)
            {
                var seq = new StringBuilder();
                for (int j = i; j < ct.Length; j += kl)
                    seq.Append(ct[j]);

                int bestS = 0;
                double minChi = double.MaxValue;

                for (int sh = 0; sh < aLen; sh++)
                {
                    double chi = 0;
                    int[] obsF = new int[aLen];
                    foreach (char c in seq.ToString())
                    {
                        int idx = alpha.IndexOf(c);
                        if (idx >= 0) obsF[idx]++;
                    }
                    for (int j = 0; j < aLen; j++)
                    {
                        double exp = expF[j % expF.Length] * seq.Length / 100.0;
                        double obs = obsF[(j + sh) % aLen];
                        if (exp > 0)
                            chi += Math.Pow(obs - exp, 2) / exp;
                    }
                    if (chi < minChi)
                    {
                        minChi = chi;
                        bestS = sh;
                    }
                }

                key.Append(alpha[bestS]);
            }

            string fKey = key.ToString();
            for (int len = 1; len <= fKey.Length / 2; len++)
            {
                if (fKey.Length % len == 0)
                {
                    string pat = fKey.Substring(0, len);
                    bool rep = true;
                    for (int i = len; i < fKey.Length; i += len)
                    {
                        if (fKey.Substring(i, len) != pat)
                        {
                            rep = false;
                            break;
                        }
                    }
                    if (rep)
                        return pat;
                }
            }
            return fKey;
        }

        private void btnHack_Click(object sender, EventArgs e)
        {
            try
            {
                string ct = txtOutput.Text.ToLower();
                if (string.IsNullOrWhiteSpace(ct))
                    throw new ArgumentException("Введите зашифрованный текст!");

                string lang = comboBox1.SelectedItem?.ToString() ?? "Русский";
                string alpha = lang == "Русский" ? RuA : EnA;
                char[] popC = lang == "Русский" ? new[] { 'о', 'е', 'а' } : new[] { 'e', 't', 'a' };

                ct = new string(ct.Where(c => alpha.Contains(c)).ToArray());

                if (string.IsNullOrWhiteSpace(ct))
                    throw new ArgumentException("После фильтрации текст пуст!");

                int kl = FindKeyLen(ct, alpha);

                string gKey = GuessKey(ct, kl, alpha, popC);

                string decTxt = VigProc(ct, gKey, false);

                txtMaybeKey.Text = gKey;
                txtHacTxt.Text = decTxt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtHacTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaybeKey_TextChanged(object sender, EventArgs e)
        {

        }
    }
}