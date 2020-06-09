import { JumpBookModel } from "./jumpBook.model";
import { DropZoneModel } from "../dropzones/dropzone.model";
import { ParachuteSystemModel } from "../parachuteSystems/parachuteSystem.model";
import { AircraftModel } from "../aircrafts/aircraft.model";

export class JumpModel {
	public Id: number;
	public Task: string;
	public Height: number;
	public FallTime: number;
	public Date: Date;
	public ModifiedAt: Date;

	public JumpBookId: number;
	public DropZoneId: number;
	public ParachuteSystemId: number;
	public AircraftId: number;
};