using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using VrmDailyPhysicalTest.DbContexts;
using VrmDailyPhysicalTest.DTO;
using VrmDailyPhysicalTest.Helper;
using VrmDailyPhysicalTest.Interface;
using VrmDailyPhysicalTest.Models;
using static VrmDailyPhysicalTest.DTO.VrmDailyPhysicalTestDTO;

namespace VrmDailyPhysicalTest.Repository
{
    public class VrmDailyPhysicalTestRepository : IVrmDailyPhysicalTest
    {
        private readonly AppDbContext _context;
        public VrmDailyPhysicalTestRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<MessageHelper> CreateAndEditVrmDailyPhysicalTest(VrmDailyPhysicalTestCommonDTO obj)
        {
            try
            {
                //MessageHelper a = new MessageHelper(); int aa;
                //a.statuscode = 1;
                //aa = 1;

                //MessageHelper x = a;
                //int xx = aa;

                //a.statuscode = 5;
                //aa = 5;


                //// a.statuscode = 5, aa = 5 
                //// x.statuscode = 5, xx = 1


                
                MessageHelper msg = new MessageHelper();
                long HeaderId = 0;
                if (obj.objHeader.IntDailyPhysicalTestId > 0) //edit
                {
                    var updateHeader = _context.TblVrmDailyPhysicalTestHeaders.Where(x => x.IntDailyPhysicalTestId == obj.objHeader.IntDailyPhysicalTestId).FirstOrDefault();

                    HeaderId = obj.objHeader.IntDailyPhysicalTestId;
                    updateHeader.IntShiftId = obj.objHeader.IntShiftId;
                    updateHeader.StrShiftName = obj.objHeader.StrShiftName;
                    updateHeader.IntVrmid = obj.objHeader.IntVrmid;
                    updateHeader.StrVrmname = obj.objHeader.StrVrmname;
                    updateHeader.IntItemTypeId= obj.objHeader.IntItemTypeId;
                    updateHeader.StrItemTypeName = obj.objHeader.StrItemTypeName;
                    updateHeader.IntBusinessUnitId = obj.objHeader.IntBusinessUnitId;
                    //updateHeader.TmTime = obj.objHeader.TmTime; // "23:30:50"
                    updateHeader.DteDate = obj.objHeader.DteDate;
                    updateHeader.NumInitialTime = obj.objHeader.NumInitialTime;
                    updateHeader.NumFinalTime = obj.objHeader.NumFinalTime;
                    updateHeader.StrRemark = obj.objHeader.StrRemark;

                    msg.Message = "Updated Successfully - res";
                    msg.statuscode = 200;
                }
                else //create
                {
                    Models.TblVrmDailyPhysicalTestHeader createHeader = new Models.TblVrmDailyPhysicalTestHeader();
                     
                    {
                        createHeader.IntBusinessUnitId = obj.objHeader.IntBusinessUnitId;
                        createHeader.IntShiftId = obj.objHeader.IntShiftId;
                        createHeader.StrShiftName = obj.objHeader.StrShiftName;
                        createHeader.IntVrmid = obj.objHeader.IntVrmid;
                        createHeader.StrVrmname = obj.objHeader.StrVrmname;
                        createHeader.IntItemTypeId = obj.objHeader.IntItemTypeId;
                        createHeader.StrItemTypeName = obj.objHeader.StrItemTypeName;
                        //createHeader.TmTime = obj.objHeader.TmTime;
                        createHeader.DteDate = obj.objHeader.DteDate;
                        createHeader.NumInitialTime = obj.objHeader.NumInitialTime;
                        createHeader.NumFinalTime = obj.objHeader.NumFinalTime;
                        createHeader.StrRemark = obj.objHeader.StrRemark;
                        createHeader.IntCreatedBy= obj.objHeader.IntCreatedBy;
                        createHeader.DteCreatedAt = DateTime.Now;
                        createHeader.IsActive = true;
                    };
                    await _context.TblVrmDailyPhysicalTestHeaders.AddAsync(createHeader);
                    await _context.SaveChangesAsync();

                    HeaderId = createHeader.IntDailyPhysicalTestId;

                    msg.Message = "Created Successfully";
                    msg.statuscode = 200;
                }
                var newList = new List<Models.TblVrmDailyPhysicalTestRow>(obj.objRow.Count);
                var editList = new List<Models.TblVrmDailyPhysicalTestRow>(obj.objRow.Count);

                foreach (var datas in obj.objRow)
                {
                    if (datas.IntRowId == 0)
                    {
                        var detalisrow = new Models.TblVrmDailyPhysicalTestRow { };

                        detalisrow.IntDailyPhysicalTestId = HeaderId;
                        detalisrow.IntTestElementId = datas.IntTestElementId;
                        detalisrow.NumTestElementValue = datas.NumTestElementValue;
                        detalisrow.IsActive = true;

                        newList.Add(detalisrow);
                    }
                    else
                    {
                        Models.TblVrmDailyPhysicalTestRow detalisrow = _context.TblVrmDailyPhysicalTestRows.FirstOrDefault(x => x.IntRowId == datas.IntRowId && x.IsActive == true);

                        if (detalisrow != null)
                        {
                            detalisrow.IntDailyPhysicalTestId = datas.IntDailyPhysicalTestId;
                            detalisrow.IntTestElementId = datas.IntTestElementId;
                            detalisrow.NumTestElementValue = datas.NumTestElementValue;
                            detalisrow.IsActive = true;
                            editList.Add(detalisrow);
                        }
                    }
                }

                var innerquery = from a in obj.objRow
                                 where a.IntRowId > 0
                                 select a.IntRowId;

                var inactiveitems = (from b in _context.TblVrmDailyPhysicalTestRows
                                     where b.IntRowId == HeaderId && !innerquery.Contains(b.IntRowId)
                                     select b).ToList();

                if (inactiveitems.Count > 0)
                {
                    inactiveitems.ForEach(itms => { itms.IsActive = false; });

                    _context.TblVrmDailyPhysicalTestRows.UpdateRange(inactiveitems);
                   // await _context.SaveChangesAsync();
                }

                if (newList.Count > 0)
                {
                    _context.TblVrmDailyPhysicalTestRows.AddRange(newList);
                    await _context.SaveChangesAsync();
                }

                if (editList.Count > 0)
                {
                    _context.TblVrmDailyPhysicalTestRows.UpdateRange(editList);
                   // await _context.SaveChangesAsync();
                }
                
                return msg;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MessageHelper> CreateVrmDailyPhysicalTest(VrmDailyPhysicalTestCommonDTO obj)
        {
            try
            {
                TblVrmDailyPhysicalTestHeader data = new TblVrmDailyPhysicalTestHeader
                {
                    
                    IntBusinessUnitId = obj.objHeader.IntBusinessUnitId,
                    IntShiftId = obj.objHeader.IntShiftId,
                    StrShiftName = obj.objHeader.StrShiftName,
                    IntItemTypeId= obj.objHeader.IntItemTypeId,
                    StrItemTypeName= obj.objHeader.StrItemTypeName,
                    IntVrmid = obj.objHeader.IntVrmid,
                    StrVrmname = obj.objHeader.StrVrmname,
                    TmTime = obj.objHeader.TmTime,
                    DteDate = obj.objHeader.DteDate,
                    NumInitialTime = obj.objHeader.NumInitialTime,
                    NumFinalTime = obj.objHeader.NumFinalTime,
                    StrRemark = obj.objHeader.StrRemark,
                    IsActive = true,
                    IntCreatedBy = obj.objHeader.IntCreatedBy,
                    DteCreatedAt = DateTime.Now,
                    IntUpdatedBy = obj.objHeader.IntUpdatedBy,
                    DteUpdateAt = DateTime.Now
                };
                var rowlist = new List<TblVrmDailyPhysicalTestRow>(obj.objRow.Count);
                foreach (var item in obj.objRow)
                {
                   
                    var row = new TblVrmDailyPhysicalTestRow
                    {
                        IntDailyPhysicalTestId = data.IntDailyPhysicalTestId,
                        IntTestElementId = item.IntTestElementId,
                        NumTestElementValue= item.NumTestElementValue,
                        IsActive = true,
                        IntCreatedBy = item.IntCreatedBy,
                        DteCreatedAt = DateTime.Now,
                        
                    };

                    rowlist.Add(row);
                }

                await _context.TblVrmDailyPhysicalTestHeaders.AddAsync(data);
                await _context.SaveChangesAsync();

                await _context.TblVrmDailyPhysicalTestRows.AddRangeAsync(rowlist);
                await _context.SaveChangesAsync();

                var msg = new MessageHelper();
                msg.Message = "Create Successfully";
                msg.statuscode = 200;
                return msg;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<VrmDailyPhysicalTestElementconfigDTO>> GetVrmDailyPhysicalTestElementconfigDDL(long BusinessUnitId)
        {
			try
			{
                var data = await (from config in _context.TblVrmDailyPhysicalTestElementconfigs
                                                  where config.IntBusinessUnitId == BusinessUnitId && config.IsActive == true
                                                  select new VrmDailyPhysicalTestElementconfigDTO
                                                  {
                                                      value = config.IntTestElementId,
                                                      label = config.StrTestElementName,
                                                      IntBusinessUnitId = config.IntBusinessUnitId,
                                                      IntUoMid = config.IntUoMid,
                                                      StrUoMname = config.StrUoMname,
                                                  }).ToListAsync();
                return data;
			}
			catch (Exception ex)
			{
				throw ex;
				
			}
        }

        
    }
}
