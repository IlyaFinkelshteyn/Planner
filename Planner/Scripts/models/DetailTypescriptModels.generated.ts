// Generated Code : Model Generator v1
interface IDeploymentDetail
{
	callsign: string;
	cyclingLevel?: CyclingLevel;
	id: number;
	name: string;
	qualification?: Qualification;
	team: number;
}
// Generated Code : Model Generator v1
interface IEventDetail
{
	ambulancesAvailable: number;
	controlPhoneNumber: string;
	cruTrackingInUse: boolean;
	cyclistsRequested: number;
	date: string | Date;
	Deployments: IDeploymentDetail[];
	description: string;
	dipsNumber: number;
	doctorsPresent: boolean;
	endTime: string | Date;
	ExpectedIncidents: IExpectedIncidentDetail[];
	expectingBadWeather: boolean;
	fallbackRadioChannel: string;
	firstAidersAvailable: number;
	firstAidUnitsAvailable: number;
	hasSeriousHistory: boolean;
	highSpeedRoadsAtEvent: boolean;
	id: number;
	location: string;
	name: string;
	NoGoAreas: INoGoAreaDetail[];
	Notes: INoteDetail[];
	paramedicsAvailable: boolean;
	postCode: string;
	radioChannel: string;
	Schedule: IScheduleItemDetail[];
	soloRespondingExpected: boolean;
	startTime: string | Date;
	status: EventStatus;
	usingAirwave: boolean;
	usingSJARadio: boolean;
	widerDistribution: boolean;
	dateConfirmed: boolean;
	created: string | Date;
	lastUpdated: string | Date;
	createdBy: string;
	updatedBy: string;
}
// Generated Code : Model Generator v1
interface IExpectedIncidentDetail
{
	id: number;
	name: string;
}
// Generated Code : Model Generator v1
interface INoGoAreaDetail
{
	id: number;
	name: string;
}
// Generated Code : Model Generator v1
interface INoteDetail
{
	id: number;
	sortNumber: number;
	text: string;
}
// Generated Code : Model Generator v1
interface IScheduleItemDetail
{
	id: number;
	action: string;
	time: string | Date;
}
