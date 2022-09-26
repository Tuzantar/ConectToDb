using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace GetReportsFromBase.Class
{
    public class Report
    {
        private bool _IsChecked;
        private int _ctx_id;
        private int _rpt_id;
        private int _szl_id;
        private string _rpt_nazwa;
        private string _szl_nazwa;
        private int _szl_stx_id;
        private string _szl_idpb;
        private string _szl_syntax;
        private string _sp;
        public int szl_stx_id { get { return _szl_stx_id; } set { _szl_stx_id = value; } }
        public string szl_idpb { get { return _szl_idpb; } set { _szl_idpb = value; } }
        public string szl_syntax { get { return _szl_syntax; } set { _szl_syntax = value; } }
        public string sp { get { return _sp; } set { _sp = value; } }
        public bool IsChecked { get { return _IsChecked; } set { _IsChecked = value; } }
        public int ctx_id { get { return _ctx_id; } set { _ctx_id = value; } }
        public int rpt_id { get { return _rpt_id; } set { _rpt_id = value; } }
        public int szl_id { get { return _szl_id; } set { _szl_id = value; } }
        public string rpt_nazwa { get { return _rpt_nazwa; } set { _rpt_nazwa = value; } }
        public string szl_nazwa { get { return _szl_nazwa; } set { _szl_nazwa = value; } }

        public Report(string rpt_nazwa, string szl_nazwa, string szl_idpb, string szl_syntax, string sp)
        {
            //_ctx_id = ctx_id;
            //_rpt_id = rpt_id;
            //_szl_id = szl_id;
            _rpt_nazwa = rpt_nazwa;
            _szl_nazwa = szl_nazwa;
            _szl_syntax = szl_syntax;
            _szl_idpb = szl_idpb;
            _sp = sp;
            IsChecked = false;
        }
    }
    public class ReportsCollection
    {
        private Collection<Report> _ReportsCollection = new Collection<Report>();
        public Collection<Report> ReportsCol { get { return _ReportsCollection; } set { _ReportsCollection = value; } }

        public ReportsCollection(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                _ReportsCollection.Add
                    (
                    new Report( 
                        row[1].ToString(),
                        row[3].ToString(),
                        row[4].ToString(),
                        row[5].ToString(),
                        row[6].ToString()
                        ));
            }
        }
    }
}
