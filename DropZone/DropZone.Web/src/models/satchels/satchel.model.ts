import { ManufacturerModel } from "../manufacturers/manufacturer.model";
import { HashBlockModel } from "../hashBlocks/hashBlock.model";
import { ParachuteSystemModel } from "../parachuteSystems/parachuteSystem.model";

export class SatchelModel {
	public Id: number;
	public MainParachuteArea: number;
	public ReserveParachuteArea: number;
	public MaintenanceDate: Date;
	public ModifiedAt: Date;

	public ManufacturerId: number;
	public HashBlockId: number;
	
	public Manufacturer: ManufacturerModel;
	public HashBlock: HashBlockModel;
	public ParachuteSystem: ParachuteSystemModel;
};