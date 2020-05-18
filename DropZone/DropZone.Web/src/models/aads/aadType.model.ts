import { ManufacturerModel } from "../manufacturers/manufacturer.model";

export class AADTypeModel {
	public id: number;
	public type: string;
	public height: number;
	public speed: number;
    public modifiedAt: Date;

	public manufacturerId: number;
    
	public manufacturer: ManufacturerModel;
};