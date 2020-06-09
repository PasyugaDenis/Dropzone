import { DropZoneModel } from "../dropzones/dropzone.model";

export class AircraftModel {
	public Id: number;
	public Type: string;
	public Capacity: number;
	public IsAvailable: boolean;
	public ModifiedAt: Date;
	
	public DropZoneId: number;
	
	public DropZone: DropZoneModel;
};