import { UserModel } from "./user.model";

export class DoctorTableModel
{
    constructor(
        public id: number = 0,
        public email: string = "",
        public name: string = "",
        public userName: string = "",
        public gender: string = "",
        public role: string = "",
        public specialization: string = "",
        public experiance: number = 0,
        public requestStatus: string = 'request',
        public availability: string = "hi",
    
       public user:UserModel=new UserModel()){

        }
  
}