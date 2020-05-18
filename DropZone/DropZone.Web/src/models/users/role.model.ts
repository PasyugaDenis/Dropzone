import { UserModel } from "./user.model";

export class RoleModel {
	public id: number;
	public value: string;
	public modifiedAt: Date;
	
	public users: UserModel[];
};