import { makeAutoObservable } from "mobx";
import { MenuItemProps } from "semantic-ui-react";

export default class CategoryStore{
    activeCategoryName:string|undefined='';

    constructor(){
        makeAutoObservable(this);
    }    

    handleActiveCategoryName = (event:React.MouseEvent<HTMLAnchorElement, MouseEvent>,data:MenuItemProps) =>{
        this.activeCategoryName=data.name;
    }
}