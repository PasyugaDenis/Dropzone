import { RoleModel } from "./role.model";
import { DropZoneModel } from "../dropzones/dropzone.model";

export class UserModel {
	public id: number;
	public email: string;
	public password: string;
	public name: string;
	public surname: string;
	public phone: string;
	public address: string;
	public birthday: Date;
	public modifiedAt: Date;

	public roleId: number;
	public dropZoneId: number;
	
	public role: RoleModel;
	public dropZone: DropZoneModel;
};