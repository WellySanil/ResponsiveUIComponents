# ResponsiveUIComponents

Rep constists of components which can help you to make responsive UI

1. [Self-Scaling](#Self-Scaling)

2. [Centralized-Scaling](#Centralized-Scaling)


### Self-Scaling

**Component name**
"C_Individual_Scaler"
 
**Instruction**
1. Add "C_Individual_Scaler" to gameobject with RectTransfrom component;
2. Set up base width and height;
3. Use one of methods in any another component or script
(may be you have any manager which listens for screen resize
, so you can call resize methods on event invoke, for example).

### Centralized-Scaling

**Components**
1. "M_Centralized_Scaler"
2. "C_Centralized_Scaler_Beacon"

**Concept**

![image](https://user-images.githubusercontent.com/94618606/226159143-1e64752a-2d9e-493c-a2eb-07ed9634ca9b.png)

**Instruction**
1. Add "C_Centralized_Scaler_Beacon" to gameobject with RectTransfrom component;
2. Set up base width and height;
3. Add "M_Centralized_Scaler" to you manager gameobject.
4. Set up "Container" field where this controller must search "C_Centralized_Scaler_Beacon" items;
5. Set up "Collect on enable" field if you want to collect when "On Enable" triggers;
6. Use one of methods "M_Centralized_Scaler" in any another component or script
(may be you have any manager which listens for screen resize
, so you can call resize methods on event invoke, for example).
