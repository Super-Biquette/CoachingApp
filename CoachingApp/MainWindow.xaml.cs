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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoachingApp;

namespace CoachingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClubData db = new ClubData();
        public MainWindow()
        {
            InitializeComponent();
            LoadMember();
        }

        // Load all patients ordered by surname then firstname
        private void LoadMember()
        {
            lstMembers.ItemsSource = db.Members
                .OrderBy(p => p.Surname)
                .ThenBy(p => p.FirstName)
                .ToList();
        }

        private void SeedData()
        {
            Member member1 = new Member
            {
                FirstName = "Niamh",
                Surname = "Kelly",
                DateOfBirth = new DateTime(1998, 3, 14),
                ContactNumber = "087 333 4455",
                MembershipType = "Senior"
            };

            Member member2 = new Member
            {
                FirstName = "Ciarán",
                Surname = "Murphy",
                DateOfBirth = new DateTime(2005, 7, 22),
                ContactNumber = "083 444 5566",
                MembershipType = "Junior"
            };

            Member member3 = new Member
            {
                FirstName = "Fiona",
                Surname = "Walsh",
                DateOfBirth = new DateTime(1975, 11, 5),
                ContactNumber = "089 555 6677",
                MembershipType = "Veteran"
            };

            #region Create Training Sessions
            TrainingSession session1 = new TrainingSession
            {
                SessionDate = new DateTime(2026, 3, 24, 18, 30, 0),
                SessionType = "Strength",
                DurationMinutes = 60,
                CoachNotes = "Good session – strong progress on squat depth. Monitor left knee.",
                MemberId = member1.MemberId
            };

            TrainingSession session2 = new TrainingSession
            {
                SessionDate = new DateTime(2026, 3, 26, 7, 0, 0),
                SessionType = "Cardio",
                DurationMinutes = 45,
                CoachNotes = "5km time trial followed by interval work. Best 5km time to date.",
                MemberId = member1.MemberId
            };


            // Sessions for Ciarán Murphy
            TrainingSession session3 = new TrainingSession
            {
                SessionDate = new DateTime(2026, 3, 25, 17, 0, 0),
                SessionType = "Skills",
                DurationMinutes = 75,
                CoachNotes = "First session back after injury. Took it easy – good attitude.",
                MemberId = member2.MemberId
            };

            TrainingSession session4 = new TrainingSession
            {
                SessionDate = new DateTime(2026, 3, 27, 17, 0, 0),
                SessionType = "Strength",
                DurationMinutes = 45,
                CoachNotes = "Light weights, focus on form. Progress from last session.",
                MemberId = member2.MemberId
            };

            // Sessions for Fiona Walsh
            TrainingSession session5 = new TrainingSession
            {
                SessionDate = new DateTime(2026, 3, 23, 9, 0, 0),
                SessionType = "Recovery",
                DurationMinutes = 30,
                CoachNotes = "Stretching and mobility work. Essential after Sunday's match.",
                MemberId = member3.MemberId
            };

            TrainingSession session6 = new TrainingSession
            {
                SessionDate = new DateTime(2026, 3, 29, 10, 0, 0),
                SessionType = "Match",
                DurationMinutes = 90,
                CoachNotes = "Strong performance throughout. Led by example in the second half.",
                MemberId = member3.MemberId
            };
        }

        private void lstMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Member member = lstMembers.SelectedItem as Member;

            if (member != null)
            {
                LoadSessions(member.MemberId);
            }
        }

        // Load training sessions for the selected member
        private void LoadSessions(int memberId)
        {
            var trainingsessions = db.TrainingSessions
                .Where(a => a.MemberId == memberId)
                .OrderBy(a => a.SessionDate)
                .ToList();

            if (trainingsessions.Count == 0)
            {
                lstTrainingSessions.ItemsSource = null;

                lstTrainingSessions.Items.Clear();

                lstTrainingSessions.Items.Add("No training sessions");
            }
            else
            {
                lstTrainingSessions.ItemsSource = trainingsessions;
            }
        }
    }
}
