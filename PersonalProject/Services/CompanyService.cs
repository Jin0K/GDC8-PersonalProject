using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




    class CompanyService
    {
        public List<Company> GetCompanyList()
        {
            CompanyDAC dac = new CompanyDAC();
            List<Company> list = dac.GetCompanyAllList();
            dac.Dispose();

            return list;
        }

        public List<Company> GetCompanySearchList(string cName)
        {
            CompanyDAC dac = new CompanyDAC();
            List<Company> list = dac.GetCompanySearchList(cName);
            dac.Dispose();

            return list;
        }

        public List<Product> GetDealDetails(int com)
        {
            CompanyDAC dac = new CompanyDAC();
            List<Product> list = dac.GetDealDetails(com);
            dac.Dispose();

            return list;
        }

        public List<Product> GetMainItems(int com)
        {
            CompanyDAC dac = new CompanyDAC();
            List<Product> list = dac.GetMainItems(com);
            dac.Dispose();

            return list;
        }

        public Company GetCompanyInfo(int comNo)
        {
            CompanyDAC dac = new CompanyDAC();
            Company compVO = dac.GetCompanyInfo(comNo);
            dac.Dispose();

            return compVO;
        }

        public bool UpdateComapny(Company com)
        {
            CompanyDAC dac = new CompanyDAC();
            bool result = dac.UpdateCompany(com);
            dac.Dispose();

            return result;
        }

        public bool DeleteCompanyInfo(int comNo)
        {
            CompanyDAC dac = new CompanyDAC();
            bool result = dac.DeleteCompanyInfo(comNo);
            dac.Dispose();

            return result;
        }
    }

