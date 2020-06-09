import { RoleModel } from "./role.model";
import { DropZoneModel } from "../dropzones/dropzone.model";

export class UserModel {
	public Id: number;
	public Email: string;
	public Password: string;
	public Name: string;
	public Surname: string;
	public Phone: string;
	public Address: string;
	public Birthday: Date;
	public ModifiedAt: Date;

	public RoleId: number;
	public DropZoneId: number;
	
	public Role: RoleModel;
	public DropZone: DropZoneModel;
};