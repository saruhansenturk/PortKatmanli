﻿using PortKatmanli.Dal.Abstract;
using PortKatmanli.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKatmanli.Dal.Concrete.EntityFramework
{
    public class EfRuleDal : IRuleDal
    {
        private readonly PortKatmanliContext _context;

        public EfRuleDal(PortKatmanliContext context)
        {
            _context = context;
        }
        public void Add(Rules rule)
        {
            _context.Rules.Add(rule);

            _context.SaveChanges();
        }

        //public CompleXModel GetJoinTable(string unitId, string category, string freightKind)            //sonradan
        //{
        //    var reult = from a in _context.Rules
        //                join b in _context.Rules on a.Category equals b.Category                         
        //                select new CompleXModel
        //                {

        //                }
        //}

        public void Delete(int ruleId)
        {
            _context.Rules.Remove(_context.Rules.FirstOrDefault(i => i.RuleHeaderId
                                                                     == ruleId));

            _context.SaveChanges();
        }

        public Rules Get(int ruleId)
        {
            return _context.Rules.Where(i => i.RuleHeaderId
                                             == ruleId).FirstOrDefault();
        }

        public List<Rules> GetAll()
        {
            return _context.Rules.ToList();
        }

        public void Update(Rules rule)
        {
            Rules ruleForUpdate = _context.Rules.FirstOrDefault(i => i.RuleHeaderId == rule.RuleHeaderId);

            ruleForUpdate.EventType = rule.EventType;
            ruleForUpdate.FreightKind = rule.FreightKind;
            ruleForUpdate.Category = rule.Category;
            ruleForUpdate.TransitState = rule.TransitState;

            _context.SaveChanges();
        }
    }

    //public class CompleXModel       //sonradan
    //{

    //}
}
