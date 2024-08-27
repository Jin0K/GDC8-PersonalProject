using PersonalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC;
using VO;


    class CommonService
    {
        public List<CommonVO> GetCodeList(string[] categories)
        {
            CommonDAC db = new CommonDAC();
            List<CommonVO> list = db.GetCodeList(categories);
            db.Dispose();

            return list;
        }

        public async Task<Message<List<CommonVO>>> GetCodeListAsync(params string[] categories)
        {
            CommonDAC db = new CommonDAC();
            Message<List<CommonVO>> result = null;

            List<CommonVO> list = db.GetCodeList(categories);

            if (list.Count > 0)
                result = new Message<List<CommonVO>> { isSuccess = true, message = "성공", Instance = list };

            db.Dispose();

            return result;
        }

        public List<CommonVO> GetParentUnit()
        {
            CommonDAC db = new CommonDAC();
            List<CommonVO> list = db.GetParentUnit();
            db.Dispose();

            return list;
        }
    }

