import { makeAutoObservable, runInAction } from "mobx";
import { MenuItemProps } from "semantic-ui-react";
import { history } from "..";
import agent from "../api/agent";
import { Category } from "../models/category";

export default class CategoryStore{
    activeCategoryName:string|undefined='';
    selectedCategoryId:string|undefined="";

    constructor(){
        makeAutoObservable(this);
    }    

    handleActiveCategoryName = (event:React.MouseEvent<HTMLAnchorElement, MouseEvent>,data:MenuItemProps) =>{
        this.activeCategoryName=data.name;
    }

    setSelectedCategory=(categoryId:string|undefined)=>{
      runInAction(()=>this.selectedCategoryId=categoryId);
    }

    getSelectedCategoryId=()=>{
      return this.selectedCategoryId;
    }

    addCategory = async(id: string | undefined, name: string) => {
      try {
        debugger
        const response = await agent.Categories.add(id, name);
        return response;
      } catch(error) {
        throw error;
      }
    }

    chooseCategory=async(consultantId:string | undefined,categoryId:string)=>{
      await agent.Categories.choose(consultantId,categoryId);
      history.push('/skills');
    }
}