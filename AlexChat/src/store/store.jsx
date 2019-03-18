import { createStore } from "redux";
import rootReducer from "../reducers/rootreducer.jsx";

const store = createStore(rootReducer);

export default store;