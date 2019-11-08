using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Cnit.Testor.Core.Server
{
    public static class QueriesUtility
    {
        private static Func<DataClassesTestorCoreDataContext, int, int, int> _isQuestInSessionFunc;

        public static Func<DataClassesTestorCoreDataContext, int, int, int> IsQuestInSessionFunc
        {
            get
            {
                if (_isQuestInSessionFunc == null)
                {
                    _isQuestInSessionFunc = CompiledQuery.Compile<DataClassesTestorCoreDataContext, int, int, int>((DataClassesTestorCoreDataContext context, int userId, int questId) =>
                      (from c in context.TestSessions
                       join x in context.TestSessionQuestions on c.TestSessionId equals x.TestSessionId
                       where c.UserId == userId && c.EndTime == null && x.QuestionId == questId
                       select c).Count());
                }
                return _isQuestInSessionFunc;
            }
        }
    }
}
