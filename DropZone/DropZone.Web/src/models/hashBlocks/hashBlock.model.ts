import { UserModel } from "../users/user.model";

export class HashBlockModel {
	public id: number;
	public value: string;
	public hash: string;
	public previousHash: string;
	public createdOn: Date;
    public modifiedAt: Date;

	public userId: number;
    public previousHashBlockId: number;
    
	public user: UserModel;
    public previousHashBlock: HashBlockModel;
};