using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GetReportsFromBase.Class
{
    internal class Report
    {
        private bool _IsChecked;
        private int _ctx_id;
        private int _rpt_id;
        private int _szl_id;
        private string _rpt_nazwa;
        private string _szl_nazwa;
        private List<ReportPart> _ReportParts;
        public bool IsChecked { get { return _IsChecked; } set { _IsChecked = value; } }
        public int ctx_id { get { return _ctx_id; } set { _ctx_id = value; } }
        public int rpt_id { get { return _rpt_id; } set { _rpt_id = value; } }
        public int szl_id { get { return _szl_id; } set { _szl_id = value; } }
        public string rpt_nazwa { get { return _rpt_nazwa; } set { _rpt_nazwa = value; } }
        public string szl_nazwa { get { return _szl_nazwa; } set { _szl_nazwa = value; } }
        public List<ReportPart> ReportParts { get { return _ReportParts; } set { _ReportParts = value; } }

        public Report()
        {
            _rpt_nazwa = "";
            _szl_nazwa = "";
            IsChecked = false;
            _ReportParts = new List<ReportPart>();
        }
    }
}
