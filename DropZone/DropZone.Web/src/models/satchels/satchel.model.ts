import { ManufacturerModel } from "../manufacturers/manufacturer.model";
import { HashBlockModel } from "../hashBlocks/hashBlock.model";
import { ParachuteSystemModel } from "../parachuteSystems/parachuteSystem.model";

export class SatchelModel {
	public id: number;
	public mainParachuteArea: number;
	public reserveParachuteArea: number;
	public maintenanceDate: Date;
	public modifiedAt: Date;

	public manufacturerId: number;
	public hashBlockId: number;
	
	public manufacturer: ManufacturerModel;
	public hashBlock: HashBlockModel;
	public parachuteSystem: ParachuteSystemModel;
};