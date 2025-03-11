using System;
using System.Linq;
using System.Windows.Forms;
using MyFinancialCrm.Models;

namespace MyFinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }

        FinancialCrmdBEntities db = new FinancialCrmdBEntities();
        private void FrmBanks_Load(object sender, EventArgs e)
        {
            var ziraatBankBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var vakifBankBalance = db.Banks.Where(x => x.BankTitle == "VakıfBank").Select(y => y.BankBalance).FirstOrDefault();
            var isBanksiBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(y => y.BankBalance).FirstOrDefault();

            lblİsBankasiBalance.Text = isBanksiBalance.ToString() + " ₺";
            lblVakifbankBalance.Text = vakifBankBalance.ToString() + " ₺";
            lblZiraatBankBalance.Text = ziraatBankBalance.ToString() + " ₺";

            //banka hareketleri
            var bankProcesses1 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();
            lblBankProcess1.Text = $"{bankProcesses1.Description} {bankProcesses1.Amount} {bankProcesses1.ProcessDate?.ToString("dd/MM/yyyy")}";

            var bankProcesses2 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = $"{bankProcesses2.Description} {bankProcesses2.Amount} {bankProcesses2.ProcessDate?.ToString("dd/MM/yyyy")}";

            var bankProcesses3 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = $"{bankProcesses3.Description} {bankProcesses3.Amount} {bankProcesses3.ProcessDate?.ToString("dd/MM/yyyy")}";

            var bankProcesses4 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = $"{bankProcesses4.Description} {bankProcesses4.Amount} {bankProcesses4.ProcessDate?.ToString("dd/MM/yyyy")}";

            var bankProcesses5 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = $"{bankProcesses5.Description} {bankProcesses5.Amount} {bankProcesses5.ProcessDate?.ToString("dd/MM/yyyy")}";

        }
    }
}
