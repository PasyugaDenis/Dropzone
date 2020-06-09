import { UserModel } from "../users/user.model";

export class HashBlockModel {
	public Id: number;
	public Value: string;
	public Hash: string;
	public PreviousHash: string;
	public CreatedOn: Date;
    public ModifiedAt: Date;

	public UserId: number;
    public PreviousHashBlockId: number;
    
	public User: UserModel;
    public PreviousHashBlock: HashBlockModel;
};