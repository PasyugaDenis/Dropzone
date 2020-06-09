import { UserModel } from "../users/user.model";
import { JumpModel } from "./jump.model";

export class JumpBookModel {
	public Id: number;
	public Category: string;
	public ModifiedAt: Date;

	public SportsmanId: number;
	
	public Sportsman: UserModel;

	public Jumps: JumpModel[];
};