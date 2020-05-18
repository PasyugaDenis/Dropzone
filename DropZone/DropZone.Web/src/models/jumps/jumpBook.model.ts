import { UserModel } from "../users/user.model";
import { JumpModel } from "./jump.model";

export class JumpBookModel {
	public id: number;
	public category: string;
	public modifiedAt: Date;

	public sportsmanId: number;
	
	public sportsman: UserModel;

	public jumps: JumpModel[];
};