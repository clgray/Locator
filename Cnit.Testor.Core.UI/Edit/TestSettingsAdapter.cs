using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.Packaging;
using Cnit.Testor.Core.UI.Edit;

namespace Cnit.Testor.Core.UI.Edit
{
    public class TestSettingsAdapter
    {
        protected TestHelper _testHelper;
        protected TestorData _data;
        protected TestorData.CoreTestsRow _currentRow;
        protected bool _hasChanges;

        public event EventHandler<EventArgs> DataChanged;

        public virtual bool HasChanges
        {
            get
            {
                return _hasChanges;
            }
            set
            {
                _hasChanges = value;
                OnHasChanges();
            }
        }

        public virtual TestorData TestorData
        {
            get
            {
                return _data;
            }
        }

        public virtual int VariantsMode
        {
            get
            {
                if (_currentRow.VariantsMode)
                    return 0;
                else
                    return 1;
            }
            set
            {
                if (VariantsMode != value)
                {
                    _currentRow.VariantsMode = (value == 0);
                    HasChanges = true;
                }
            }
        }

        public virtual int TestId
        {
            get
            {
                return _currentRow.TestId;
            }
        }

        public virtual bool AllowAdmitQuestions
        {
            get
            {
                return _currentRow.AllowAdmitQuestions;
            }
            set
            {
                if (_currentRow.AllowAdmitQuestions != value)
                {
                    _currentRow.AllowAdmitQuestions = value;
                    HasChanges = true;
                }
            }
        }

        public virtual bool ShowTestResult
        {
            get
            {
                return _currentRow.ShowTestResult;
            }
            set
            {
                if (_currentRow.ShowTestResult != value)
                {
                    _currentRow.ShowTestResult = value;
                    HasChanges = true;
                }
            }
        }

        public virtual bool ShowDetailsTestResult
        {
            get
            {
                return _currentRow.ShowDetailsTestResult;
            }
            set
            {
                if (_currentRow.ShowDetailsTestResult != value)
                {
                    _currentRow.ShowDetailsTestResult = value;
                    HasChanges = true;
                }
            }
        }

        public virtual DateTime BeginTime
        {
            get
            {
                return _currentRow.BeginTime;
            }
            set
            {
                if (_currentRow.BeginTime != value)
                {
                    _currentRow.BeginTime = value;
                    HasChanges = true;
                }
            }
        }

        public virtual DateTime EndTime
        {
            get
            {
                return _currentRow.EndTime;
            }
            set
            {
                if (_currentRow.EndTime != value)
                {
                    _currentRow.EndTime = value;
                    HasChanges = true;
                }
            }
        }

        public virtual int TimeLimit
        {
            get
            {
                return _currentRow.TimeLimit;
            }
            set
            {
                if (_currentRow.TimeLimit != value)
                {
                    _currentRow.TimeLimit = value;
                    HasChanges = true;
                }
            }
        }

        public virtual short QuestionsNumber
        {
            get
            {
                return _currentRow.QuestionsNumber;
            }
            set
            {
                if (_currentRow.QuestionsNumber != value)
                {
                    if (_testHelper != null)
                    {
                        if (value > _testHelper.QuestCount)
                        {
                            MessageBox.Show(String.Format("Превышено число вопросов.\nКол-во вопросов в тесте: {0}.",
                                _testHelper.QuestCount.ToString()));
                            return;
                        }
                    }
                    _currentRow.QuestionsNumber = value;
                    HasChanges = true;
                }
            }
        }

        public virtual double PassingScore
        {
            get
            {
                return _currentRow.PassingScore;
            }
            set
            {
                if (_currentRow.PassingScore != value)
                {
                    _currentRow.PassingScore = value;
                    HasChanges = true;
                }
            }
        }

        public virtual bool IsMasterTest
        {
            get
            {
                return _currentRow.IsMasterTest;
            }
        }

        public virtual short PassagesNumber
        {
            get
            {
                return _currentRow.PassagesNumber;
            }
            set
            {
                if (_currentRow.PassagesNumber != value)
                {
                    _currentRow.PassagesNumber = value;
                    HasChanges = true;
                }
            }
        }

        public virtual bool ShowRightAnswersCount
        {
            get
            {
                return _currentRow.ShowRightAnswersCount;
            }
            set
            {
                if (_currentRow.ShowRightAnswersCount != value)
                {
                    _currentRow.ShowRightAnswersCount = value;
                    HasChanges = true;
                }
            }
        }

        public virtual bool IsActive
        {
            get
            {
                return _currentRow.IsActive;
            }
            set
            {
                if (_currentRow.IsActive == value)
                    return;
                _currentRow.IsActive = value;
                HasChanges = true;
            }
        }

        public virtual string TestName
        {
            get
            {
                return _currentRow.TestName;
            }
            set
            {
                string newName = value.Trim();
                if (newName == _currentRow.TestName)
                    return;
                if (newName.Length == 0)
                    return;
                if (_testHelper != null)
                {
                    if (ProjectState.TestHelpers.Where(c => c.TestName == newName).Count() > 0)
                    {
                        SystemMessage.ShowWarningMessage("Данное имя теста уже используется.");
                        return;
                    }
                    _testHelper.TestName = newName;
                }
                _currentRow.TestName = newName;
                HasChanges = true;
            }
        }

        public virtual string Description
        {
            get
            {
                return _currentRow.Description;
            }
            set
            {
                string description = value.Trim();
                if (_currentRow.Description != description)
                {
                    _currentRow.Description = description;
                    HasChanges = true;
                }
            }
        }
        
        public virtual TestorAdaptiveMode AdaptiveMode
        {
            get
            {
                return (TestorAdaptiveMode)_currentRow.AdaptiveMode;
            }
            set
            {
                short mode = (short)value;
                if (_currentRow.AdaptiveMode != mode)
                {
                    _currentRow.AdaptiveMode = mode;
                    HasChanges = true;
                }
            }
        }
        

        public TestSettingsAdapter(TestorData data)
        {
            _data = data;
            _currentRow = _data.CoreTests[0];
        }

        public TestSettingsAdapter(TestHelper testHelper)
        {
            _testHelper = testHelper;
            _data = _testHelper.TestorData;
            _currentRow = _data.CoreTests[0];
        }

        public virtual void OnHasChanges()
        {
            if (_testHelper != null)
                ProjectState.HasChanges = true;
            if (DataChanged != null)
                DataChanged(this, new EventArgs());
        }
    }
}
