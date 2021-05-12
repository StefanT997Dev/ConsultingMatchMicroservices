import React from "react";
import { Container } from "semantic-ui-react";
import Navbar from "./Navbar";
import ConsultantDashboard from "../../features/consultants/dashboard/ConsultantDashboard";
import { observer } from "mobx-react-lite";
import { Route, Switch } from "react-router-dom";
import HomePage from "../../features/home/HomePage";
import LoginForm from "../../features/users/LoginForm";
import Profile from "../../features/profile/Profile";
import Calendly from "./Calendly";
import TestErrors from "../../features/errors/TestError";
import { ToastContainer } from "react-toastify";
import NotFound from "../../features/errors/NotFound";

const App = () => {
  return (
    <div>
      <ToastContainer position="bottom-right" hideProgressBar />
      <Navbar />
      <Container style={{ marginTop: "7em" }}>
        <Switch>
          <Route exact path="/" component={HomePage} />
          <Route path="/login" component={LoginForm} />
          <Route exact path="/consultants" component={ConsultantDashboard} />
          <Route path="/profile" component={Profile} />
          <Route path="/consultants/hire" component={Calendly} />
          <Route path="/consultants/:id" component={Profile} />
          <Route path="/errors" component={TestErrors} />
          <Route component={NotFound} />
        </Switch>
      </Container>
    </div>
  );
};

export default observer(App);
