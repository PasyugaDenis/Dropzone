import { ParachuteModel } from "../parachutes/parachute.model";
import { AADModel } from "../aads/aad.model";
import { SatchelModel } from "../satchels/satchel.model";
import { UserModel } from "../users/user.model";
import { HashBlockModel } from "../hashBlocks/hashBlock.model";

export class ParachuteSystemModel {
	public id: number;
    public modifiedAt: Date;

	public mainParachuteId: number;
	public reserveParachuteId: number;
	public aadId: number;
	public satchelId: number;
	public userId: number;
    public hashBlockId: number;
    
	public mainParachute: ParachuteModel;
	public reserveParachute: ParachuteModel;
	public aad: AADModel;
	public satchel: SatchelModel;
	public user: UserModel;
    public hashBlock: HashBlockModel;
};