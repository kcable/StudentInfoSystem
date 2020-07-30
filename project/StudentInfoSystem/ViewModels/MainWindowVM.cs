using StudentInfoSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    public class MainWindowVM : ObservableObject
    {
        Student st;
        //nameTxt.Text = st.firstName;
        //    sureNameTxt.Text = st.sureName;
        //    lastNameTxt.Text = st.lastName;
        //    faculyTxt.Text = st.faculty;
        //    specialtTxt.Text = st.specialnost;
        //    oksTxt.Text = st.major;
        //    statusTxt.Text = st.status;
        //    facNumTxt.Text = st.facultyNumber;
        //    courseTxt.Text = Convert.ToString(st.course);
        //    potokTxt.Text = Convert.ToString(st.potok);
        //    groupTxt.Text = Convert.ToString(st.group);
        private string _firstName;
        public string FirstName
        {
            get
            {
                if (string.IsNullOrEmpty(_firstName))
                {
                    return st.firstName;
                }

                return _firstName;

            }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string _diploma;
        public string Diploma
        {
            get
            {
                if (string.IsNullOrEmpty(_diploma))
                {
                    DiplomaContext context = new DiplomaContext();
                    Diploma result = (from dp in context.Diplomas where dp.student == st.facultyNumber select dp).First();
                    return result.topic;
                }

                return _diploma;

            }
            set
            {
                _diploma = value;
                OnPropertyChanged("Diploma");
            }
        }


        private string _sureName;
        public string SureName
        {
            get
            {
                if (string.IsNullOrEmpty(_sureName))
                {
                    return st.sureName;
                }

                return _sureName;

            }
            set
            {
                _sureName = value;
                OnPropertyChanged("SureName");
            }
        }


        private string _lastName;
        public string LastName
        {
            get
            {
                if (string.IsNullOrEmpty(_lastName))
                {
                    return st.lastName;
                }

                return _lastName;

            }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string _facNumber;
        public string FacNumber
        {
            get
            {
                if (string.IsNullOrEmpty(_facNumber))
                {
                    return st.facultyNumber;
                }

                return _facNumber;

            }
            set
            {
                _facNumber = value;
                OnPropertyChanged("FacNumber");
            }
        }



        private string _specialnost;
        public string Specialnost
        {
            get
            {
                if (string.IsNullOrEmpty(_specialnost))
                {
                    return st.specialnost;
                }

                return _specialnost;

            }
            set
            {
                _specialnost = value;
                OnPropertyChanged("Specialnost");
            }
        }

        private string _oks;
        public string Oks
        {
            get
            {
                if (string.IsNullOrEmpty(_oks))
                {
                    return st.major;
                }

                return _oks;

            }
            set
            {
                _oks = value;
                OnPropertyChanged("Oks");
            }
        }

        private string _status;
        public string Status
        {
            get
            {
                if (string.IsNullOrEmpty(_status))
                {
                    return st.status;
                }

                return _status;

            }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        private string _faculty;
        public string Faculty
        {
            get
            {
                if (string.IsNullOrEmpty(_faculty))
                {
                    return st.faculty;
                }

                return _faculty;

            }
            set
            {
                _faculty = value;
                OnPropertyChanged("Faculty");
            }
        }

        private string _course;
        public string Course
        {
            get
            {
                if (string.IsNullOrEmpty(_course))
                {
                    return Convert.ToString(st.course);
                }

                return _course;

            }
            set
            {
                _course = value;
                OnPropertyChanged("Course");
            }
        }


        private string _potok;
        public string Potok
        {
            get
            {
                if (string.IsNullOrEmpty(_potok))
                {
                    return Convert.ToString(st.potok);
                }

                return _potok;

            }
            set
            {
                _potok = value;
                OnPropertyChanged("Potok");
            }
        }

        private string _group;
        public string Group
        {
            get
            {
                if (string.IsNullOrEmpty(_group))
                {
                    return Convert.ToString(st.group);
                }

                return _group;

            }
            set
            {
                _group = value;
                OnPropertyChanged("Group");
            }
        }


        public RelayCommand PopulateCommand { get; private set; }

        public void Populate(object obj)
        {

            FirstName = st.firstName;
            SureName = st.sureName;
            LastName = st.lastName;
            Faculty = st.faculty;
            Specialnost = st.specialnost;
            Oks = st.major;
            Status = st.status;
            FacNumber = st.facultyNumber;
            Course = Convert.ToString(st.course);
            Potok = Convert.ToString(st.potok);
            Group = Convert.ToString(st.group);
            DiplomaContext context = new DiplomaContext();
            Diploma result = (from dp in context.Diplomas where dp.student == st.facultyNumber select dp).First();
            Diploma = result.topic;
        }
        public MainWindowVM(User tempuser)
        {
            st = StudentValidation.IsThereStudent(tempuser);
            if (tempuser.userRole == 4) { PopulateCommand = new RelayCommand(Populate); }

        }
    }
}
