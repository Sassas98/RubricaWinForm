namespace RubricaWinForm {


    public partial class Rubrica : Form {
        private PhoneBookData db;

        public Rubrica() {
            InitializeComponent();
            db = new();
        }

        private void button1_Click(object sender, EventArgs e) {
            string s = textBox1.Text;
            var v = FromListToDouple(s.Split(" ").ToList());
            s = db.NewNumber(v.Item1, v.Item2) ? "" : "non ";
            textBox2.Text = "Operazione " + s + "eseguita!";
        }

        private void button2_Click(object sender, EventArgs e) {
            string s = textBox1.Text;
            s = FromListToString(s.Split(" ").ToList());
            s = db.Remove(s) ? "" : "non ";
            textBox2.Text = "Operazione " + s + "eseguita!";
        }

        private void button3_Click(object sender, EventArgs e) {
            string s = textBox1.Text;
            s = FromListToString(s.Split(" ").ToList());
            var l = db.Search(s);
            textBox2.Lines = l.Count is 0 ? new string[] { "Nessun contatto trovato." } : ResutlRightFormat(l);
        }

        //converte una lista di stringhe in una coppia di stringhe: il corpo e la stringa finale
        private (string, string) FromListToDouple(List<string> items) {
            string num = items[items.Count - 1];
            items.Remove(num);
            return (FromListToString(items), num);
        }

        //converte una lista di stringhe in una stringa
        private string FromListToString(List<string> items) {
            return items.Count is 0 ? "" : items.Aggregate((a, b) => a + " " + b);
        }

        private string[] ResutlRightFormat(List<string> items) {
            List<string> list = new List<string>();
            foreach (var item in items) {
                list.Add("");
                item.Split("\n").ToList().ForEach(line => list.Add(line));
            }
            return list.ToArray();
        }
    }
}