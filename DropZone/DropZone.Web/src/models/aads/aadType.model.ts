import { ManufacturerModel } from "../manufacturers/manufacturer.model";

export class AADTypeModel {
	public Id: number;
	public Type: string;
	public Height: number;
	public Speed: number;
    public ModifiedAt: Date;

	public ManufacturerId: number;
    
	public Manufacturer: ManufacturerModel;
};