import { AADTypeModel } from "./aadType.model";
import { ParachuteSystemModel } from "../parachuteSystems/parachuteSystem.model";
import { HashBlockModel } from "../hashBlocks/hashBlock.model";

export class AADModel {
	public id: number;
	public maintenanceDate: Date;
    public modifiedAt: Date;

	public aadTypeId: number;
    public hashBlockId: number;
    
	public aadType: AADTypeModel;
	public hashBlock: HashBlockModel;
	public parachuteSystem: ParachuteSystemModel;
};