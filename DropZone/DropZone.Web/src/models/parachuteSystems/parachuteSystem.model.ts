import { ParachuteModel } from "../parachutes/parachute.model";
import { AADModel } from "../aads/aad.model";
import { SatchelModel } from "../satchels/satchel.model";
import { UserModel } from "../users/user.model";
import { HashBlockModel } from "../hashBlocks/hashBlock.model";

export class ParachuteSystemModel {
	public Id: number;
    public ModifiedAt: Date;

	public MainParachuteId: number;
	public ReserveParachuteId: number;
	public AADId: number;
	public SatchelId: number;
	public UserId: number;
    public HashBlockId: number;
    
	public MainParachute: ParachuteModel;
	public ReserveParachute: ParachuteModel;
	public AAD: AADModel;
	public Satchel: SatchelModel;
	public User: UserModel;
    public HashBlock: HashBlockModel;
};