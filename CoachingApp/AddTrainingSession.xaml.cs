using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CoachingApp
{
    /// <summary>
    /// Interaction logic for AddTrainingSession.xaml
    /// </summary>
    public partial class AddTrainingSession : Window
    {
        private ClubData db = new ClubData();

        private Member selectedMember;

        private TrainingSession selectedTrainingSession;
        public AddTrainingSession(Member member)
        {
            InitializeComponent();
            selectedMember = member;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = dpDate.SelectedDate.Value;

            TimeSpan time = TimeSpan.Parse(tpTime.Text);

            date = date.Add(time);

            // Create new TrainingSession
            TrainingSession newSession = new TrainingSession
            {
                SessionDate = date,
                SessionType = cbType.Text,
                DurationMinutes = 0,
                CoachNotes = txtNotes.Text,
                MemberId = selectedMember.MemberId
            };

            db.TrainingSessions.Add(newSession);

            db.SaveChanges();

            MessageBox.Show("TrainingSession Saved");

            Close();
        }
    }
}
