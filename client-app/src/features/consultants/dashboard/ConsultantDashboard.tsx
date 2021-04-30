import { observer } from "mobx-react-lite";
import React from "react";
import { Grid, RatingProps, TextAreaProps } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import ConsultantDetails from "../details/ConsultantDetails";
import ConsultantContactForm from "../form/ConsultantContact";
import ConsultantList from "./ConsultantList";

export default observer(function ConsultantDashboard() {
  const {consultantStore} = useStore();
  const {commonStore} = useStore();

  return (
    <Grid>
      <Grid.Column width="10">
        {consultantStore.consultants?<ConsultantList/>:null}
      </Grid.Column>
      <Grid.Column width='6'>
        {consultantStore.selectedConsultant && <ConsultantDetails/>}
        {commonStore.displayConsultantContact?<ConsultantContactForm/>:null}
      </Grid.Column>
    </Grid>
  );
})
