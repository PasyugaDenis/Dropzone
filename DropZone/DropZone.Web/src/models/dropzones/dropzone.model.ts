import { AircraftModel } from "../aircrafts/aircraft.model";
import { UserModel } from "../users/user.model";

export class DropZoneModel {
	public id: number;
	public title: string;
	public country: string;
	public runwayType: string;
	public runwayLength: number;
	public square: number;
	public latitude: number;
	public longitude: number;
	public modifiedAt: Date;
	
	public aircrafts: AircraftModel[];
	public users: UserModel[];
};