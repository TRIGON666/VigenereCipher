using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VigenereCipherApp
{
    public partial class Form1 : Form
    {
        private const string RussianLetters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private const string EnglishLetters = "abcdefghijklmnopqrstuvwxyz";

        private const string RussianAlphabet = RussianLetters + "0123456789";
        private const string EnglishAlphabet = EnglishLetters + "0123456789";

        public Form1()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtInput.ScrollBars = ScrollBars.Vertical;
            
            comboBox1.Items.AddRange(new[] { "Русский", "Английский" });
            comboBox1.SelectedIndex = 0;
        }

        private string ProcessVigenere(string text, string key, bool encrypt)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
                throw new ArgumentException("Текст или ключ не могут быть пустыми!");

            string selectedLanguage = comboBox1.SelectedItem.ToString();
            string alphabet;
            if (selectedLanguage == "Русский")
            {
                alphabet = RussianAlphabet;
            }
            else
            {
                alphabet = EnglishAlphabet;
            }

            ValidateInput(text, key, alphabet, selectedLanguage);

            key = key.Replace(" ", "").ToLower();
            var result = new StringBuilder();
            int keyPosition = 0;

            foreach (char symbol in text.ToLower())
            {
                int symbolIndex = alphabet.IndexOf(symbol);
                if (symbolIndex == -1)
                    throw new ArgumentException("Недопустимый символ");

                int keyShift = alphabet.IndexOf(key[keyPosition % key.Length]);
                int shift = 0;
                if (encrypt)
                {
                    shift = keyShift;
                }
                else
                {
                    shift = -keyShift;
                }

                int newIndex = (symbolIndex + shift + alphabet.Length) % alphabet.Length;
                result.Append(alphabet[newIndex]);
                keyPosition++;
            }

            return result.ToString();
        }

        private void ValidateInput(string text, string key, string alphabet, string selectedLanguage)
        {
            foreach (char c in key)
            {
                if (!alphabet.Contains(c))
                    throw new ArgumentException("Ключ содержит недопустимый символ");
            }

            bool hasRussian = text.Any(c => RussianLetters.Contains(c));
            bool hasEnglish = text.Any(c => EnglishLetters.Contains(c));

            if (hasRussian && selectedLanguage != "Русский")
                throw new ArgumentException("Текст содержит русские буквы, но выбран английский алфавит!");

            if (hasEnglish && selectedLanguage != "Английский")
                throw new ArgumentException("Текст содержит английские буквы, но выбран русский алфавит!");

            foreach (char c in text)
            {
                if (!alphabet.Contains(c))
                    throw new ArgumentException("Текст содержит недопустимый символ");
            }
        }

        private void ProcessButtonClick(bool encrypt)
        {
            try
            {
                string text = txtInput.Text;
                string key = tKey.Text;

                if (string.IsNullOrWhiteSpace(key))
                    throw new ArgumentException("Введите ключ!");

                txtOutput.Text = ProcessVigenere(text, key, encrypt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enc_Click(object sender, EventArgs e) => ProcessButtonClick(encrypt: true);
        private void dec_Click(object sender, EventArgs e) => ProcessButtonClick(encrypt: false);
    }
}