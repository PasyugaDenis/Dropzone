import { DropZoneModel } from "../dropzones/dropzone.model";

export class AircraftModel {
	public id: number;
	public type: string;
	public capacity: number;
	public isAvailable: boolean;
	public modifiedAt: Date;
	
	public dropZoneId: number;
	
	public dropZone: DropZoneModel[];
};