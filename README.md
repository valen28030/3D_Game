<h1 align="justify">3D_Game</h1>

<h2 align="justify">Introducción</h2>
<p align="justify">El presente informe detalla el desarrollo de un juego de acción en tercera persona ambientado en un oscuro cementerio llamado "Shadow Quest: Monastery's Demise", donde un valiente monje debe enfrentarse a un demonio maligno que lo persigue. El jugador controla al monje, utilizando habilidades de combate y estrategia para derrotar al enemigo y salvar su monasterio de la perdición.</p>

&nbsp;

<h2 align="justify">Desarrollo del Juego</h2>
<p align="justify">He creado una serie de scripts para los controles del juego, pero el principal es el script "Controlador"</p>
<h3 align="justify">Control de Personaje</h3>
<p align="justify">El juego presenta un controlador de personaje completo y pulido que permite al jugador mover al monje por el entorno del cementerio con fluidez y precisión. Se han implementado sistemas de movimiento, salto, carrera y ataques estilo ninja.</p>
<ul>
  <li><strong>Movimiento Fluido:</strong> El jugador puede controlar el movimiento del monje con su teclado, permitiendo desplazamientos suaves en todas las direcciones.</li>
  <li><strong>Saltos y Carreras:</strong> El monje puede realizar saltos y carreras, agregando profundidad al movimiento y permitiendo al jugador superar obstáculos y explorar el entorno de manera dinámica.</li>
  <li><strong>Ataques Estilo Ninja:</strong> Se ha integrado un sistema de ataques estilo ninja que permite al jugador realizar patadas y otros movimientos ofensivos, brindando una experiencia de combate satisfactoria y fluida.</li>
</ul>

```sh
// Movimiento del personaje
public void Movimiento()
{
    Horizontal = Input.GetAxis("Horizontal");
    Vertical = Input.GetAxis("Vertical");

    // Control de velocidad y dirección del movimiento
    Rigid.velocity = new Vector3(Horizontal * Speed, Rigid.velocity.y, Vertical * Speed);
    
    // Animación del personaje según la velocidad de movimiento
    MonjeAnim.SetFloat("VelMov", new Vector3(Horizontal, 0, Vertical).magnitude);
    
    // Funciones para saltar, correr, y realizar ataques
    Saltar();
    Correr();
    RealizarAtaque();
}
```

![MOVE-_online-video-cutter com_-_1_ (1) (1) (1)](https://github.com/valen28030/3D_Game/assets/167770750/3c1e7391-d689-4f85-9823-a5f7e43d347e)

&nbsp;


<h3 align="justify">Cámara en Tercera Persona</h3>
<p align="justify">La cámara sigue al personaje en tercera persona, proporcionando una visión clara del entorno del juego mientras el jugador explora el cementerio y enfrenta al demonio. </p>
<ul>
  <li><strong>Seguimiento Suave:</strong> La cámara sigue al monje con movimientos suaves y naturales, asegurando que el jugador siempre tenga una vista clara de su entorno sin interrupciones bruscas.</li>
</ul>

```sh
// Seguimiento suave del personaje por la cámara
public void SeguirPersonaje()
{
    // Actualización de la posición y rotación de la cámara según la posición del personaje
    Vector3 offset = new Vector3(0, 3, -5); // Offset para mantener la cámara detrás y sobre el personaje
    transform.position = monje.transform.position + offset;
    transform.LookAt(monje.transform.position); // Mantener la cámara mirando al personaje
}
```
&nbsp;


<h3 align="justify">Escenario y Estética</h3>
<p align="justify">El cementerio está diseñado con una estética coherente y espeluznante, utilizando assets 3D descargados de Internet. Se han asignado materiales e iluminación para darle un aspecto pulido y razonable, creando una atmósfera inmersiva y siniestra.</p>
<p align="left">
<img src="https://github.com/valen28030/3D_Game/assets/167770750/d0e2f2ea-b5e2-4de0-8cc5-a88e65b67134" width="800">
</p>

&nbsp;


<h3 align="justify">Sistema de Combate</h3>
<p align="justify">El monje tiene la capacidad de derrotar al demonio mediante patadas estilo ninja. Se ha implementado un sistema de combate que permite al jugador realizar ataques y defenderse del enemigo.</p>
<ul>
  <li><strong>Ataques y Defensas:</strong> Se ha implementado un sistema de combate que permite al jugador realizar una variedad de ataques, como patadas y golpes, así como defenderse de los ataques del enemigo.</li>
  <li><strong>Interacciones Fluidas:</strong> Los ataques del jugador y del enemigo están sincronizados de manera fluida, lo que garantiza una experiencia de combate dinámica y satisfactoria.</li>
  
```sh
// Función para realizar ataques del personaje
public void RealizarAtaque()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        MonjeAnim.SetTrigger("Ataque");
        // Lógica para detectar colisiones y dañar al enemigo
        DetectarEnemigo();
    }
}
```
<li><strong>Disparo Laser:</strong> Cada cierto tiempo un Laser atacara al jugador que sin capacidad de poder esquivarlo le restara 5 puntos.</li>

```sh
public void FireLaser()
{
    puntos -= 5;
    Vida.text = "Vida: " + puntos;
}
```
</ul>

<p align="left">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="https://github.com/valen28030/3D_Game/assets/167770750/3c814456-3b74-4590-a87e-88eff39b181c" width="300">
</p>

&nbsp;


<h3 align="justify">Inteligencia Artificial del Enemigo</h3>
<p align="justify">El demonio sigue una lógica concreta y puede detectar al jugador de alguna manera. Utiliza esta lógica para perseguir al monje y atacarlo, creando un desafío emocionante para el jugador.</p>
<ul>
  <li><strong>Persecución y Ataque:</strong> El demonio utiliza una lógica de persecución para rastrear al monje y atacarlo cuando está cerca, creando una sensación de tensión y desafío para el jugador.</li>
  <li><strong>Comportamiento Reactivo:</strong> El enemigo responde de manera dinámica a las acciones del jugador, lo que garantiza que cada encuentro sea único y desafiante.</li>
</ul>

```sh
// Función para seguir al jugador
public void SeguirJugador()
{
    // Cálculo de la dirección hacia la posición actual del jugador
    Vector3 direccion = (jugador.transform.position - transform.position).normalized;
    // Movimiento hacia la posición del jugador con una velocidad controlada
    Demonio.Move(direccion * velocidadPersecucion * Time.deltaTime);
}
```

&nbsp;


<h3 align="justify">Gestión del Raycast</h3>
<p align="justify">Método que gestiona el raycast para detectar colisiones y actualizar el LineRenderer del láser.</p> 

```sh
public void Raycast() 
{
    // Realiza un raycast desde el objetivo hacia el personaje principal
    if (Physics.Raycast(Target.transform.position, Target.transform.position, out R, 100))
    {
        Target.transform.position = R.point;
        if (R.transform.tag == "Prota")
        {
            Destroy(R.transform.gameObject);
        }
    }
    // Actualiza el LineRenderer para visualizar el rayo láser
    Laser.SetPosition(0, Target.transform.position);
    Laser.SetPosition(1, Monje.transform.position);
}
```

&nbsp;


<h3 align="justify">Script AgenteController</h3>
<p align="justify">El script AgenteController controla el comportamiento del enemigo y su interacción con el personaje principal. Aquí está una parte relevante de este script:</p> 

```sh
// Configuración del destino del enemigo (demonio) para seguir al personaje principal
void Update()
{
    Demonio.SetDestination(Monje.transform.position + new Vector3(-2,2,0));
}

// Detecta colisiones con el personaje principal y resta vida
public void OnCollisionEnter(Collision collision)
{
    Laser.RestarScore();
}
```

&nbsp;


<h3 align="justify">Script Muerte</h3>
<p align="justify">El script Muerte maneja las colisiones entre el personaje principal y el enemigo, así como la destrucción del enemigo cuando el personaje principal muere. Aquí está una parte relevante de este script:</p> 

```sh
// Maneja las colisiones con el personaje principal y resta vida al enemigo
private void OnTriggerEnter(Collider other)
{
    if (other.tag == "Prota") {
        Controlador.RestarEnemy();
    }
}

// Destruye al enemigo (demonio) y reinicia la escena
public void Destruir() {
    Destroy(Demon);
    SceneManager.LoadScene(0);
}
```
&nbsp;


<h3 align="justify">Script Vida</h3>
<p align="justify">El script Vida gestiona las interacciones relacionadas con la vida del personaje principal. Aquí está una descripción de su funcionalidad:</p> 

```sh
// Maneja las colisiones con objetos etiquetados como "Enemy" y resta vida al personaje principal
private void OnTriggerEnter(Collider other)
{
    if (other.tag == "Enemy") {
        Controlador.RestarScore();
    }
}

// Método que reinicia la escena cuando el personaje principal muere
public void Recargar()
{
    SceneManager.LoadScene(0);
}

// Método que indica al controlador que el personaje principal está en movimiento
public void Inmove() 
{
    Controlador.move = false;
}
```

&nbsp;


<h3 align="justify">Script Musica</h3>
<p align="justify">El script Musica se encarga de reproducir y gestionar la música de fondo del juego. Aquí está una descripción de su funcionalidad:</p> 

```sh
// Reproduce una canción específica identificada por su ID
public void Reproducir(int id) 
{
    musica.clip = canciones[id];
    cancionsonando = id;
    musica.Play();
}

// Método que avanza automáticamente a la siguiente canción cuando una canción termina
public void NextAutomatico()
{
    if (musica.clip != null)
    {
        if (musica.isPlaying && musica.time >= musica.clip.length - 0.1f) // 0.1f es un pequeño margen para asegurarse de que hemos llegado al final.
        {
            Next();
        }
    }
}

// Método que avanza a la siguiente canción en la lista de reproducción
public void Next()
{
    cancionsonando++;
    if (cancionsonando >= canciones.Length)
    {
            cancionsonando = 0;
    }
    Reproducir(cancionsonando);
}
```
&nbsp;


<h3 align="justify">Interfaz de Usuario</h3>
<p align="justify">Se ha creado un interfaz que muestra la vida del monje y del enemigo, permitiendo al jugador controlar su estado de salud durante el combate. Además, se han implementado formas de recuperar la vida del monje para aumentar su durabilidad en la batalla.</p>

&nbsp;


<h3 align="justify">Optimización de Assets</h3>
<p align="justify">Se ha incorporado un sistema de optimización de assets utilizando Occlusion Culling, garantizando un rendimiento óptimo del juego sin comprometer la calidad visual del entorno del cementerio.</p>

&nbsp;


<h2 align="justify">Requisitos del Sistema</h2>
<ul align="justify">
  <li><strong>Plataforma:</strong> Disponible para Windows, macOS y Linux.</li>
  <li><strong>Requisitos Mínimos de Hardware:</strong> Se recomienda un procesador de al menos 2.0 GHz, 4 GB de RAM y una tarjeta gráfica compatible con DirectX 11.</li>
</ul>

&nbsp;


<h2 align="justify">Conclusiones</h2>
<p align="justify">El desarrollo de "Shadow Quest: Monastery's Demise" ha sido un éxito, ofreciendo una experiencia de juego emocionante y desafiante para los jugadores. La implementación eficiente de sistemas de juego y la atención al detalle en el diseño del entorno y los personajes han contribuido a crear un juego envolvente y satisfactorio.</p>
<p align="justify">En resumen, "Shadow Quest: Monastery's Demise" es un juego que combina acción, estrategia y una atmósfera inquietante para ofrecer una experiencia única y emocionante a los jugadores.</p>

&nbsp;

## Créditos

- **Desarrollador**: Carlos Valencia Sánchez
- **Diseñador de Juego**: Carlos Valencia Sánchez
- **Artista Gráfico**: Carlos Valencia Sánchez

&nbsp;

## Contacto

Para obtener soporte técnico, reportar errores o proporcionar comentarios, no dudes en contactar.

---

<p align="justify">Este documento proporciona una visión general del juego, incluyendo sus características, tecnología utilizada, requisitos del sistema, instrucciones de juego y créditos. Para obtener más información detallada sobre el desarrollo y funcionamiento del juego, consulta la documentación interna o comunícate con el desarrollador.</p>
