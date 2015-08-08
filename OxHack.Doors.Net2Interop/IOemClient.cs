using Paxton.Net2.OemClientLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxHack.Doors.Net2Interop
{
	public interface IOemClient : IDisposable
	{
		//bool CanAuthenticate
		//{
		//	get;
		//}
		//string ClientSessionName
		//{
		//	get;
		//}
		//int CurrentUserID
		//{
		//	get;
		//}
		//bool IsOperatorLoggedOn
		//{
		//	get;
		//}
		//Guid LastCreatedUserGuid
		//{
		//	get;
		//	set;
		//}
		//int LastCreatedUserId
		//{
		//	get;
		//	set;
		//}
		//string LastErrorMessage
		//{
		//	get;
		//}
		//string ServerHostName
		//{
		//	get;
		//}
		//DateTime ServerLastChecked
		//{
		//	get;
		//}
		//DateTime ServerLastStarted
		//{
		//	get;
		//}
		//string UserName
		//{
		//	get;
		//}
		//bool _importBatchInitiated
		//{
		//	get;
		//}
		//event EasyproxDiagnosticValuesReceivedEventHandler EasyproxDiagnosticValuesReceivedEvent;
		//event Net2AcuEventHandler Net2AccessEvent;
		//event Net2AcuEventHandler Net2DoorStatusChangedEvent;
		//event Net2ServerDisconnectedHandler Net2ServerDisconnected;
		//event Net2ServerReconnectedHandler Net2ServerReconnected;
		//bool ActivateIoBoardRelays(int ioBoardId, IoBoardRelaySetting[] relaysToActivate);
		//bool AddAccessLevel(string accessLevelName, AccessLevelDetailSet accessLevelDetail);
		//bool AddACU(int serialNumber, int deviceType);
		//bool AddACU(int serialNumber, int deviceType, int doorGroupId);
		bool AddCard(int cardNo, int cardTypeId, int userId);
		//bool AddClockInRecord(int UserId);
		//bool AddClockInRecord(int UserId, DateTime ClockInDateTime);
		//bool AddClockOutRecord(int UserId);
		//bool AddClockOutRecord(int UserId, DateTime ClockOutDateTime);
		//int AddCustomOperatorTemplate(string templateName, string departmentList, string accessLevelList, bool showEvents);
		//bool AddDepartment(string deptName);
		//int AddDoorGroup(string doorGroupName);
		//bool AddEventRecord(EventViewEnums.Net2EventTypes eventType, EventViewEnums.Net2EventSubTypes eventSubType, int deviceAddress, short deviceSubAddr, string userId, int cardNo, string eventDetail, int linkedEventId, int ioBoardId, int inputId, int outputId);
		//bool AddOperatorFromGroup(Guid originatingSite, Guid userGuid, string firstName, string middleName, string surname, int opRoleId, int accessLevelId, int departmentId, string emailAddress, string mobileNumber, bool groupAdmin, string password, int rights);
		//bool AddPeerToGroup(Guid siteGuid, string siteName, bool isGroupAdmin);
		//bool AddStaffCategories(StaffCategoriesSet.StaffCategoryRow[] newCatRows);
		//int AddThirdPartyApplication(string appName);
		//bool AddTimesheetCategories(TimesheetCategoriesSet.TimesheetCategoryRow[] newCatRows);
		//bool AddTimesheetEntryMultiple(TimesheetDetailsSet.TimesheetDetailRow[] newEntries);
		//bool AddTimesheetEntryOwnDept(int categoryId, int deptId, DateTime startDateTime, DateTime endDateTime, bool includeWeekends);
		//bool AddTimesheetEntryOwnRecord(int categoryId, int userId, DateTime startDateTime, DateTime endDateTime, bool includeWeekends);
		//bool AddTimesheetEntryToAll(int categoryId, DateTime startDateTime, DateTime endDateTime, bool includeWeekends);
		//bool AddTimezone(string newTimezoneName, TimezonesSet.TimeslotsRow[] newSlots);
		//int AddUserFromGroup(string userXml);
		//bool AddUserRecord(IIndividualReaderAreas readerAreas, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, int cardNumber, int cardTypeId, bool active, string faxNo, DateTime expiryDate, string[] customFields);
		bool AddUserRecord(int accessLevelId, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, int cardNumber, int cardTypeId, bool active, string faxNo, DateTime expiryDate, string[] customFields);
		//bool AddUserRecord(IIndividualReaderAreas readerAreas, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, int cardNumber, int cardTypeId, bool active, string faxNo, DateTime expiryDate, string[] customFields, bool lockdownExempt);
		//bool AddUserRecord(IIndividualReaderAreas readerAreas, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, int cardNumber, int cardTypeId, bool active, string faxNo, DateTime expiryDate, string[] customFields, System.Drawing.Image userPicture);
		//bool AddUserRecord(int accessLevelId, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, int cardNumber, int cardTypeId, bool active, string faxNo, DateTime expiryDate, string[] customFields, bool lockdownExempt);
		//bool AddUserRecord(int accessLevelId, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, int cardNumber, int cardTypeId, bool active, string faxNo, DateTime expiryDate, string[] customFields, System.Drawing.Image userPicture);
		//bool AddUserRecord(IIndividualReaderAreas readerAreas, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, int cardNumber, int cardTypeId, bool active, string faxNo, DateTime expiryDate, string[] customFields, System.Drawing.Image userPicture, bool lockdownExempt);
		//bool AddUserRecord(int accessLevelId, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, int cardNumber, int cardTypeId, bool active, string faxNo, DateTime expiryDate, string[] customFields, System.Drawing.Image userPicture, bool lockdownExempt);
		//bool AddUserToImportBatch(int accessLevelId, int departmentId, bool antiPassbackInd, bool alarmUser, bool lockdownExempt, bool accessLevelUser, string firstName, string middleName, string surname, string telephoneNo, string telephoneExt, string faxNo, string pinNumber, string pictureFile, DateTime activateDate, DateTime expiryDate, string cardNo, int cardType, bool cardLost, List<KeyValuePair<int, string>> customFields, IIndividualReaderAreas readerAreas, System.Drawing.Image userImage = null);
		//bool AddVehicleRegistration(int userId, string vehicleIndexMark);
		//bool AreDoorsBeingSynchronised();
		//bool AttachThirdPartyUserRef(int net2UserId, string tpRef, int applicationId);
		//Dictionary<string, int> AuthenticateUser(Guid operatorGuid, string password);
		Dictionary<string, int> AuthenticateUser(int userIdent, string password);
		//bool AuthenticateUser(Guid operatorGuid, string password, out Dictionary<string, int> methodsDictionary);
		//bool AuthenticateUser(int userId, string password, out Dictionary<string, int> methodsDictionary);
		//bool CloseDoor(int acuAddress);
		//Dictionary<string, int> ConnectTimesheetClient(int userIdent, string password);
		//bool ControlDoorEx(int address, byte relay, byte function, uint dooropenTime, byte ledFlash);
		//bool DeleteAccessLevel(int accessLevelId);
		//bool DeleteACU(int serialNumber);
		bool DeleteCard(int cardNo);
		//bool DeleteCustomOperatorTemplate(int templateId);
		//bool DeleteDepartment(int deptId);
		//bool DeleteOemSetting(string name);
		//bool DeleteStaffCategories(int[] catIds);
		//bool DeleteThirdPartyApplication(int appId);
		//bool DeleteTimesheetCategories(int[] catIds);
		//bool DeleteTimesheetEntries(TimesheetDetailsSet.TimesheetDetailRow[] entryData);
		//bool DeleteTimezone(int timezoneId);
		//bool DeleteVehicleRegistration(int userId, string vehicleIndexMark);
		//bool DetachThirdPartyUserRef(int net2UserId, string tpRef, int applicationId);
		//bool Detect();
		//void EndImportBatch();
		//bool EndLockdown();
		//bool FlashAccessDenied(int acuAddress, int readerId);
		//bool FlashAccessPermitted(int acuAddress, int readerId);
		//byte[] GetApplicationSetting(string applicationName, string settingName, string userName);
		//DataSet GetEventDescriptions(int fromEventID, int toEventID);
		//List<Tuple<string, int?, string, bool, string>> GetImportBatchResults();
		IOperators GetListOfOperators();
		//byte[] GetOemSetting(string name);
		//int GetOperatorLevel(Guid userGUID);
		//int GetOperatorLevel(int userID);
		//OemClient.ProductType GetProductType();
		//bool HoldDoorOpen(int acuAddress);
		//bool ImportPublicHolidays();
		//bool InitiateLockdown();
		//bool IsUserPermittedThroughDoor(Guid userGUID, int acuSerialNumber, int acuSubAddress, DateTime dateTime);
		//bool IsUserPermittedThroughDoor(int userID, int acuSerialNumber, int acuSubAddress, DateTime dateTime);
		//bool MonitorAcu(int acuAddress);
		//bool MonitorAcuStatus(int acuSerialNo);
		//bool OpenDoor(int[] suppliedAddresses);
		//bool OpenDoor(string doorName);
		//bool OpenDoor(int acuAddress);
		//bool OpenDoor(int acuAddress, int doorOpenTime);
		//bool OpenDoor(int acuAddress, Guid operatorId);
		//bool PrintCardTemplate(int userId, int cardId);
		//bool PrintCardTemplate(int userId, int cardId, string printer);
		//bool ProcessImportUserBatch();
		//bool PurgeUser(int userId);
		//DataSet QueryDb(string sqlText);
		//DataSet QueryDb(string storedProcName, SqlParameter[] prms);
		//bool RemoveDoorGroup(int doorGroupID);
		//bool RemoveOperatorFromGroup(Guid userGuid);
		//bool RemovePeerFromGroup(Guid siteGuid);
		//bool RemoveUserFromGroup(Guid userGuid);
		//bool RenameDoorGroup(int doorGroupID, string doorGroupName);
		//bool RequestAccess(string readerIdentity, IVehicleIndex anprToken);
		//bool RequestEasyproxDiagnostics(uint SerialNumber);
		//bool RevokeAllTemporaryAccessAssignments();
		//bool RevokeDepartmentTemporaryAccess(int departmentId);
		//bool RevokeUserTemporaryAccess(List<int> userIds);
		//bool RevokeUserTemporaryAccess(int userId);
		//bool SetApplicationSetting(string applicationName, string settingName, string userName, byte[] valueBlob);
		//bool SetDepartmentTemporaryAccess(int departmentId, int accessLevelId, DateTime expiryDateTime);
		//bool SetDepartmentTemporaryAccess(int departmentId, int accessLevelId, TimeSpan duration);
		//bool SetDoorOpenTime(int acuAddress, int doorOpenTime);
		//bool SetFieldname(OemClient.FieldnameFlags fieldId, string value);
		//bool SetUserTemporaryAccess(int userId, int accessLevelId, DateTime expiryDateTime);
		//bool SetUserTemporaryAccess(List<int> userIds, int accessLevelId, DateTime expiryDateTime);
		//bool SetUserTemporaryAccess(List<int> userIds, int accessLevelId, TimeSpan duration);
		//bool SetUserTemporaryAccess(int userId, int accessLevelId, TimeSpan duration);
		//bool SilenceAlarm(int[] serialNos);
		//bool StartImportBatch();
		//bool StopMonitoringAcu(int acuAddress);
		//bool StopMonitoringAcuStatus(int acuAddress);
		//bool TransferHoliday(int yearOfAdjustment, DateTime priorHolidayYearStart, DateTime priorHolidayYearEnd);
		//bool UpdateAccessLevel(int accessLevelId, string accessLevelName, AccessLevelDetailSet accessLevelDetail);
		//bool UpdateCard(CardsSet.CardRow cardToModify);
		//bool UpdateCustomOperatorTemplate(int templateId, string templateName, string departmentList, string accessLevelList, bool showEvents);
		//bool UpdateDepartment(int deptId, string deptName);
		//bool UpdateDoorGroupForDoor(int serialNumber, int doorGroupID);
		//bool UpdateOemSetting(string name, byte[] data);
		//bool UpdateStaffCategories(StaffCategoriesSet.StaffCategoryRow[] catRows);
		//bool UpdateThirdPartyApplication(int appId, string appName);
		//bool UpdateTimesheetCategories(TimesheetCategoriesSet.TimesheetCategoryRow[] catRows);
		//bool UpdateTimesheetEntries(TimesheetDetailsSet.TimesheetDetailRow[] entryData);
		//bool UpdateTimesheetUsersDetail(int yearOfReference, TimesheetUsersDetailSet.TimesheetUsersDetailRow[] userRows);
		//bool UpdateTimezone(int timezoneId, TimezonesSet.TimeslotsRow[] newSlots);
		//bool UpdateTimezone(int timezoneId, string newTimezoneName);
		//bool UpdateTimezone(int timezoneId, string newTimezoneName, TimezonesSet.TimeslotsRow[] newSlots);
		//bool UpdateUserRecord(int userId, IIndividualReaderAreas readerAreas, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, bool activeInd, string faxNo, DateTime expiryDate, string[] customFields);
		bool UpdateUserRecord(int userId, int accessLevelId, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, bool activeInd, string faxNo, DateTime expiryDate, string[] customFields);
		//bool UpdateUserRecord(int userId, IIndividualReaderAreas readerAreas, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, bool activeInd, string faxNo, DateTime expiryDate, string[] customFields, bool lockdownExempt);
		//bool UpdateUserRecord(int userId, int accessLevelId, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, bool activeInd, string faxNo, DateTime expiryDate, string[] customFields, bool lockdownExempt);
		//bool UpdateUserRecord(int userId, IIndividualReaderAreas readerAreas, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, bool activeInd, string faxNo, DateTime expiryDate, string[] customFields, System.Drawing.Image userPicture, bool deleteImage);
		//bool UpdateUserRecord(int userId, int accessLevelId, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, bool activeInd, string faxNo, DateTime expiryDate, string[] customFields, System.Drawing.Image userPicture, bool deleteImage);
		//bool UpdateUserRecord(int userId, IIndividualReaderAreas readerAreas, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, bool activeInd, string faxNo, DateTime expiryDate, string[] customFields, System.Drawing.Image userPicture, bool deleteImage, bool lockdownExempt);
		//bool UpdateUserRecord(int userId, int accessLevelId, int departmentId, bool antiPassbackInd, bool alarmUserInd, string firstName, string middleName, string surname, string telephoneNo, string telephoneExtension, string pinCode, string pictureFileName, DateTime activationDate, bool activeInd, string faxNo, DateTime expiryDate, string[] customFields, System.Drawing.Image userPicture, bool deleteImage, bool lockdownExempt);
		//bool UserCanCallMethod(string methodName);
		//bool UserHasTemporaryAccess(int userId);
		//bool ValidateOperator(int userId, string password, out Dictionary<string, int> availableMethods);
		//IAccessLevelDetails ViewAccessLevelDetail(int accessLevelId);
		//IAccessLevels ViewAccessLevels();
		//IIndividualReaderAreas ViewAccessLevels(int userId);
		//ICameraAuthentications ViewCameraAuthentications();
		//ICameras ViewCameras(int address);
		List<int> ViewCards(int userId);
		//ICards ViewCardsSet(int userId);
		//ICardTemplates ViewCardTemplates();
		//ICardTypes ViewCardTypes();
		IDepartments ViewDepartments();
		//IDoorGroups ViewDoorGroups();
		//IDoors ViewDoors();
		//IDoors ViewDoors(int serialNo);
		//IDoors ViewDoorsSet();
		//IEvents ViewEvents(int maxRowsReturned, string sortDirection);
		//IEvents ViewEvents(int maxRowsReturned, string whereClause, string orderBy);
		IEvents ViewEvents(int maxRowsReturned, DateTime startDate, DateTime endDate, string startTime, string endTime, bool accessEvents, bool infoEvents, bool alarmEvents, bool systemEvents, bool warningEvents, string firstName, string surname, string evnt, string evntDetail, string deviceName, int minEventID);
		//IIoBoardInputs ViewIoBoardInputs(int ioBoardId);
		//IIoBoardOutputs ViewIoBoardOutputs(int ioBoardId);
		//IIoBoards ViewIoBoards();
		//string[] ViewOemSettings();
		//IStaffCategories ViewStaffCategories();
		//KeyValuePair<int, string>[] ViewThirdPartyApplications();
		//ReadOnlyCollection<ThirdPartyReference> ViewThirdPartyUserRefs(int? net2UserId, string tpRef);
		//ITimesheetCategories ViewTimesheetCategories();
		//ITimesheetDetail ViewTimesheetDetail(int[] userId, DateTime startDate, DateTime endDate);
		//ITimesheetDetail ViewTimesheetDetail(int userId, DateTime startDate, DateTime endDate);
		//ITimesheetEventLogs ViewTimesheetEventLogs(DateTime startDate, DateTime endDate);
		//ITimesheetSummary ViewTimesheetSummary(int deptId, DateTime startDate, DateTime endDate, DateTime holsStartDate, DateTime holsEndDate);
		//ITimesheetUsersDetail ViewTimesheetUsersDetail(int timesheetYear);
		//ITimezones ViewTimezones();
		//ITimezones ViewTimezones(bool tzOnly);
		//ITimezones ViewTimezones(int tzId, bool tzOnly);
		IUsers ViewUserRecords();
		IUsers ViewUserRecords(string sqlWhereClause);
		//IUsers ViewUserRecords(string sqlWhereClause, bool includeImages);
	}
}
