using System;
using System.Collections.Generic;
using System.Text;

namespace FFCG.Generation.Meteorolog.Host.Presenters
{
    public class PresentAll : IPresenter
    {
        private readonly List<IPresenter> _presenters;
        public PresentAll(List<IPresenter> presenters)
        {
            _presenters = presenters;
        }

        public void Present(List<DailyValues> dailyValues)
        {
            foreach (var presenter in _presenters)
            {
                presenter.Present(dailyValues);
            }

        }
    }
}
