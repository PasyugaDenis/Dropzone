import { JumpBookModel } from "./jumpBook.model";
import { DropZoneModel } from "../dropzones/dropzone.model";
import { ParachuteSystemModel } from "../parachuteSystems/parachuteSystem.model";
import { AircraftModel } from "../aircrafts/aircraft.model";

export class JumpModel {
	public id: number;
	public task: string;
	public height: number;
	public fallTime: number;
	public date: Date;
	public modifiedAt: Date;

	public jumpBookId: number;
	public dropZoneId: number;
	public parachuteSystemId: number;
	public aircraftId: number;
	
	public jumpBook: JumpBookModel;
	public dropZone: DropZoneModel;
	public parachuteSystem: ParachuteSystemModel;
	public aircraft: AircraftModel;
};