import React, { useEffect, useState } from 'react';
import { NavLink } from 'react-router-dom';
import { Button, Container, Input, Menu, MenuItemProps, SemanticCOLORS } from 'semantic-ui-react';
import { SemanticWIDTHS } from 'semantic-ui-react/dist/commonjs/generic';
import agent from '../api/agent';
import { Category } from '../models/category';

export default function Navbar(){
    const activeColor = 'blue';

    const [categories,setCategories]=useState<Category[]>([]);
    const [activeCategory,setActiveCategory] = useState<string | undefined>(categories[0]?.name);

    useEffect(()=>{
        agent.Categories.list().then(response=>{
          setCategories(response);
        })
    },[])

    const handleActiveCategory = (event:React.MouseEvent<HTMLAnchorElement, MouseEvent>,data:MenuItemProps) =>{
        setActiveCategory(data.name);
    }
    
    return(
        <div>
            <Menu style={{marginTop:'0px',marginBottom:'0px'}} inverted>
                <Container>
                    <Menu.Item header as={NavLink} to='/' exact>
                        <img src="/assets/logo.png" alt="logo"/>
                        ConsultingMatch
                    </Menu.Item>
                    <Menu.Item name='Feed' as={NavLink} to='/feed'/>
                    <Menu.Item as={NavLink} to='/profile'>
                        <Button positive content='Profile'/>
                    </Menu.Item>
                    <Menu.Item style={{width:'40em'}}>
                        <Input icon='search' placeholder='Search for a consultant...' />
                    </Menu.Item>
                    <Menu.Item name='Communities' as={NavLink} to='/communities'/>
                    <Menu.Item name='Logout' as={NavLink} to='/' exact/>
                </Container>
            </Menu>
            
            <Menu style={{marginTop:'1px',marginBottom:'0px'}} inverted widths={categories.length as SemanticWIDTHS}>
            {categories.map(category => (
            <Menu.Item
                key={category.id}
                name={category.name}
                active={activeCategory===category.name}
                color={activeColor}
                onClick={handleActiveCategory}
            />
            ))}
            </Menu>
        </div>
    )
}