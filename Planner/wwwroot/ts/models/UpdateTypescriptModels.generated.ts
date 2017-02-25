// Generated Code : Model Generator v1
interface IEmailUpdate
{
	id: number;
	name: string;
	address: string;
	wideList: boolean;
}
// Generated Code : Model Generator v1
interface IDeploymentUpdate
{
	callsign: string;
	cyclingLevel?: CyclingLevel;
	id: number;
	name: string;
	qualification?: Qualification;
	team: number;
}
// Generated Code : Model Generator v1
interface IEventUpdate
{
	ambulancesAvailable: number;
	controlPhoneNumber: string;
	cruTrackingInUse: boolean;
	cyclistsRequested: number;
	date: string | Date;
	description: string;
	dipsNumber: number;
	doctorsPresent: boolean;
	endTime: string | Date;
	expectingBadWeather: boolean;
	fallbackRadioChannel: string;
	firstAidersAvailable: number;
	firstAidUnitsAvailable: number;
	hasSeriousHistory: boolean;
	highSpeedRoadsAtEvent: boolean;
	id: number;
	location: string;
	name: string;
	paramedicsAvailable: boolean;
	postCode: string;
	radioChannel: string;
	soloRespondingExpected: boolean;
	startTime: string | Date;
	status: EventStatus;
	usingAirwave: boolean;
	usingSJARadio: boolean;
	widerDistribution: boolean;
	dateConfirmed: boolean;
}
// Generated Code : Model Generator v1
interface IScheduleItemUpdate
{
	id: number;
	action: string;
	time: string | Date;
}
