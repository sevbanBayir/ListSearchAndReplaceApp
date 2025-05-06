using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ListSearchAndReplaceApp
{
    public partial class Form1 : Form
    {
        private List<int> numbers = new List<int> { 10, 20, 30, 40, 50, 60, 70 };
        private int? lastSearchedValue = null;
        private int lastFoundIndex = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateListLabel();
            resultLabel.Text = "App loaded.";
        }

        private void UpdateListLabel()
        {
            listLabel.Text = "Current List: " + string.Join(", ", numbers);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            lastSearchedValue = null;
            lastFoundIndex = -1;
            if (int.TryParse(searchTextBox.Text, out int searchValue))
            {
                lastSearchedValue = searchValue;
                lastFoundIndex = numbers.IndexOf(searchValue);
                if (lastFoundIndex != -1)
                {
                    resultLabel.Text = $"Found {searchValue} at index {lastFoundIndex}.";
                }
                else
                {
                    resultLabel.Text = $"{searchValue} not found.";
                }
            }
            else
            {
                resultLabel.Text = "Invalid search input. Enter a number.";
            }
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            if (lastSearchedValue == null || lastFoundIndex == -1)
            {
                resultLabel.Text = "Please search for a value first.";
                return;
            }

            if (int.TryParse(replaceTextBox.Text, out int replaceValue))
            {
                numbers[lastFoundIndex] = replaceValue;
                resultLabel.Text = $"Replaced {lastSearchedValue} with {replaceValue}.";
                UpdateListLabel();
                searchTextBox.Text = string.Empty;
                replaceTextBox.Text = string.Empty;
                lastSearchedValue = null;
                lastFoundIndex = -1;
            }
            else
            {
                resultLabel.Text = "Invalid replace input. Enter a number.";
            }
        }
    }
}
