import { UserModel } from "./user.model";

export class InternModel
{
    constructor(public id:number= 0,
        public name:string="",
        public email:string="",
        public userName:string="",
        public phoneNumber:string="",
        public gender:string="",
        public userPassword:string="",
        public role:string="",

        public user:UserModel=new UserModel()){

        }
  
}