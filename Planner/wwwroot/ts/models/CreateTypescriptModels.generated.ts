// Generated Code : Model Generator v1
interface IEmailCreate
{
	name: string;
	address: string;
	wideList: boolean;
}
// Generated Code : Model Generator v1
interface IDeploymentCreate
{
	callsign: string;
	cyclingLevel?: CyclingLevel;
	name: string;
	qualification?: Qualification;
	team: number;
}
// Generated Code : Model Generator v1
interface IEventCreate
{
	cyclistsRequested: number;
	date: string | Date;
	dipsNumber: number;
	endTime: string | Date;
	location: string;
	name: string;
	startTime: string | Date;
	status: EventStatus;
	dateConfirmed: boolean;
}
// Generated Code : Model Generator v1
interface IExpectedIncidentCreate
{
	name: string;
}
// Generated Code : Model Generator v1
interface INoGoAreaCreate
{
	name: string;
}
// Generated Code : Model Generator v1
interface INoteCreate
{
	sortNumber: number;
	text: string;
}
// Generated Code : Model Generator v1
interface IScheduleItemCreate
{
	action: string;
	time: string | Date;
}
