import { ManufacturerModel } from "../manufacturers/manufacturer.model";
import { HashBlockModel } from "../hashBlocks/hashBlock.model";

export class ParachuteModel {
	public Id: number;
	public Area: number;
	public LayingVolume: number;
	public Weight: number;
	public LayingCount: number;
	public SectionCount: number;
	public IsReserve: boolean;
	public LayingDate: Date;
	public MaintenanceDate: Date;
	public ModifiedAt: Date;

	public ManufacturerId: number;
	public HashBlockId: number;
	
	public Manufacturer: ManufacturerModel;
	public HashBlock: HashBlockModel;
};