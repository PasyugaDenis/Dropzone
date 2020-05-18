import { ManufacturerModel } from "../manufacturers/manufacturer.model";
import { HashBlockModel } from "../hashBlocks/hashBlock.model";

export class ParachuteModel {
	public id: number;
	public area: number;
	public layingVolume: number;
	public weight: number;
	public layingCount: number;
	public sectionCount: number;
	public isReserve: boolean;
	public layingDate: Date;
	public maintenanceDate: Date;
	public modifiedAt: Date;

	public manufacturerId: number;
	public hashBlockId: number;
	
	public manufacturer: ManufacturerModel;
	public hashBlock: HashBlockModel;
};