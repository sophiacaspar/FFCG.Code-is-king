using System;
using System.Collections.Generic;
using System.Text;

namespace FFCG.Generation.Meteorolog
{
    public interface IPresenter
    {
        void Present(List<DailyValues> dailyValues);
    }
}
