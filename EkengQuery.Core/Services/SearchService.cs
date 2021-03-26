using System;
using System.Collections.Generic;
using System.Linq;


namespace EkengQuery.Core
{
    public class SearchService: ISearchService
    {
        private readonly SearchContext _content;
        public SearchService(SearchContext content)
        {
            _content = content;
        }

      public  List<ApplicantModel> GetResultWithOutPassport(string firstName, string lastName)
        {
            List<Applicant> searchApplicant = _content.Applicant.Where(p => (p.ApplicantFirstName.Contains(firstName) && p.ApplicantLastName.Contains(lastName))).ToList();


            List<OldCerteficate> searchFromAllCitizens = _content.OldCerteficate.Where(p => (p.LastName.Contains(lastName) && p.FirstName.Contains(firstName))).ToList();


            List<ApplicantModel> searchApplicantsViewModel = new List<ApplicantModel>();

            foreach (var item in searchApplicant)
            {
                var searchCommunity = _content.Community.FirstOrDefault(p => p.CommunityId == item.TrainingCenterCommunityId);
                var searchRegion = _content.Region.FirstOrDefault(p => p.RegionId == searchCommunity.RegionId);
                var searchData = _content.TrainingCourse.FirstOrDefault(p => p.TrainingCourseCode == item.TrainingCourseCode);
                DateTime? dataValide = item.CertificateIssue;
                string DataValide = null;
                if (dataValide != null)
                {
                    DateTime dateTime = (DateTime)dataValide;
                    DateTime dateTimeNew = dateTime.AddYears(3);
                    DataValide = dateTimeNew.ToString("dd.MM.yyyy");
                }


                string trainingRoom;
                string dataTraining;
                if (searchData != null)
                {
                    var serachTrainingRoom = _content.TrainingCenter.FirstOrDefault(p => p.TrainingCenterId == searchData.TrainingCenterId);
                    dataTraining = (searchData.DateTime).ToString("dd.MM.yyyy HH:mm");
                    trainingRoom = serachTrainingRoom.Address;
                }
                else
                {
                    trainingRoom = null;
                    dataTraining = null;
                }


                string CommunityName = searchCommunity.CommunityName;
                string RegionName = searchRegion.RegionName;
                string grupeTraining = item.TrainingCourseCode;


                ApplicantModel applicantsViewModel = new ApplicantModel
                {

                    //ApplicantId = item.ApplicantId,
                    FullName = item.ApplicantLastName + " " + item.ApplicantFirstName + " " + item.ApplicantMiddleName,
                    Address = item.Address,
                    TrainingCenter = grupeTraining + "," + CommunityName + "," + RegionName + "(" + trainingRoom + ")(" + dataTraining + ")",
                    // TrainingCenter = null,
                    Points = item.Points,
                    CertificateNumber = (item.CertificateNumber).ToString(),
                    Date = DataValide,
                };
                searchApplicantsViewModel.Add(applicantsViewModel);

            }

            foreach (var item in searchFromAllCitizens)
            {

                ApplicantModel applicantsViewModel = new ApplicantModel
                {

                    //ApplicantId = item.ApplicantId,
                    FullName = item.LastName + " " + item.FirstName + " " + item.MiddleName,
                    Address = item.Address,
                    TrainingCenter = item.TrainingCenter,
                    Points = item.Points,
                    CertificateNumber = item.Certeficate,
                    Date = item.Date,
                };
                searchApplicantsViewModel.Add(applicantsViewModel);

            }

            return searchApplicantsViewModel;
        }

      public List<ApplicantModel> GetResultWithPassport(string firstName, string lastName, string passport)
        {
            List<Applicant> searchApplicant = _content.Applicant.Where(p => (p.ApplicantFirstName.Contains(firstName) && p.ApplicantLastName.Contains(lastName) && p.PassportNumber == passport)).ToList();

            //List<OldCerteficate> searchFromAllCitizens = cont.OldCerteficate.Where(p => (p.FirstName == firstName && p.LastName == lastName && p.Passport == passport)).ToList();
            List<OldCerteficate> searchFromAllCitizens = _content.OldCerteficate.Where(p => (p.LastName.Contains(lastName) && p.FirstName.Contains(firstName) && p.Passport == passport)).ToList();

            List<ApplicantModel> searchApplicantsViewModel = new List<ApplicantModel>();

            foreach (var item in searchApplicant)
            {

                var searchCommunity = _content.Community.FirstOrDefault(p => p.CommunityId == item.TrainingCenterCommunityId);
                var searchRegion = _content.Region.FirstOrDefault(p => p.RegionId == searchCommunity.RegionId);
                var searchData = _content.TrainingCourse.FirstOrDefault(p => p.TrainingCourseCode == item.TrainingCourseCode);
                DateTime? dataValide = item.CertificateIssue;
                string DataValide = null;
                if (dataValide != null)
                {
                    DateTime dateTime = (DateTime)dataValide;
                    DateTime dateTimeNew = dateTime.AddYears(3);
                    DataValide = dateTimeNew.ToString("dd.MM.yyyy");
                }


                string trainingRoom;
                string dataTraining;
                if (searchData != null)
                {
                    var serachTrainingRoom = _content.TrainingCenter.FirstOrDefault(p => p.TrainingCenterId == searchData.TrainingCenterId);
                    dataTraining = (searchData.DateTime).ToString("dd.MM.yyyy HH:mm");
                    trainingRoom = serachTrainingRoom.Address;
                }
                else
                {
                    trainingRoom = null;
                    dataTraining = null;
                }

                string CommunityName = searchCommunity.CommunityName;
                string RegionName = searchRegion.RegionName;
                string grupeTraining = item.TrainingCourseCode;

                ApplicantModel applicantsViewModel = new ApplicantModel
                {

                    //ApplicantId = item.ApplicantId,
                    FullName = item.ApplicantLastName + " " + item.ApplicantFirstName + " " + item.ApplicantMiddleName,
                    Address = item.Address,
                    TrainingCenter = grupeTraining + "," + CommunityName + "," + RegionName + "(" + trainingRoom + ")(" + dataTraining + ")",
                    Points = item.Points,
                    CertificateNumber = (item.CertificateNumber).ToString(),
                    Date = DataValide,
                };
                searchApplicantsViewModel.Add(applicantsViewModel);

            }

            foreach (var item in searchFromAllCitizens)
            {

                ApplicantModel applicantsViewModel = new ApplicantModel
                {

                    //ApplicantId = item.ApplicantId,
                    FullName = item.LastName + " " + item.FirstName + " " + item.MiddleName,
                    Address = item.Address,
                    TrainingCenter = item.TrainingCenter,
                    Points = item.Points,
                    CertificateNumber = item.Certeficate,
                    Date = item.Date,
                };
                searchApplicantsViewModel.Add(applicantsViewModel);

            }
            return searchApplicantsViewModel;
        }
    }
}
