import { AADTypeModel } from "./aadType.model";
import { ParachuteSystemModel } from "../parachuteSystems/parachuteSystem.model";
import { HashBlockModel } from "../hashBlocks/hashBlock.model";

export class AADModel {
	public Id: number;
	public MaintenanceDate: Date;
    public ModifiedAt: Date;

	public AADTypeId: number;
    public HashBlockId: number;
    
	public AADType: AADTypeModel;
	public HashBlock: HashBlockModel;
	public ParachuteSystem: ParachuteSystemModel;
};