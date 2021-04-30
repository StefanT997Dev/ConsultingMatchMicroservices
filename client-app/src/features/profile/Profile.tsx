import React from 'react';
import { Card, Item, Segment } from 'semantic-ui-react';

export default function Profile(){
    return(
        <div>
        <Card
            image='/images/avatar/large/elliot.jpg'
            header='Elliot Baker'
            meta='Friend'
            description='Elliot is a sound engineer living in Nashville who enjoys playing guitar and hanging with his cat.'
            extra="16 friends"
        />

        <Segment>
            <Item.Group divided>
                <Item.Header>
                    <p>sdadasdds</p>
                </Item.Header>
                <Item.Description>
                    <p>Post description</p>
                </Item.Description>
            </Item.Group>
        </Segment>
        </div>
    )
}