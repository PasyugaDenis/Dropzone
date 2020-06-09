import { AircraftModel } from "../aircrafts/aircraft.model";
import { UserModel } from "../users/user.model";

export class DropZoneModel {
	public Id: number;
	public Title: string;
	public Country: string;
	public RunwayType: string;
	public RunwayLength: number;
	public Square: number;
	public Latitude: number;
	public Longitude: number;
	public RegistrationDate: Date;
	public ModifiedAt: Date;
	
	public Aircrafts: AircraftModel[];
	public Users: UserModel[];
};